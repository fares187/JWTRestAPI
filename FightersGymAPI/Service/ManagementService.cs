using AutoMapper;
using FightersGymAPI.data;
using FightersGymAPI.Models;
using FightersGymAPI.Models.added;
using FightersGymAPI.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace FightersGymAPI.Service
{
    public class ManagementService : IManagementService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ManagementService(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }
        public async Task<AuthModel> RecordAttendance(AttendanceViewModel model)
        {
            var user = _context.Members.Include(c => c.Membership)
                .Include(c => c.Payments)
                .FirstOrDefault(m => m.Barcode == model.BarCode.ToString());

            if (user is null)
                return new AuthModel() { Massage = "this Member do not exits." };
            if (user.Membership.EndDate.Date < DateTime.Today)
                return new AuthModel() { Massage = "Subscription has been  expired" };
            if (user.DaysLeft <= 0)
                return new AuthModel() { Massage = "Membership days have ended" };
            user.DaysLeft -= 1;
            user.LastAttendanceDate = DateTime.UtcNow;
            Attendance attendance = new Attendance()
            {
                BarCode = int.Parse(user.Barcode),
                Datetime = user.LastAttendanceDate,
                MemberId = user.Id,

            };
            _context.Update(attendance);
            _context.Update(user);
            _context.SaveChanges();
            return new AuthModel() { Massage = null };
        }

        public async Task<AuthModel> RegisterNewMember(NewMemberViewModel model)
        {
            var userbarcode = _context.Members.FirstOrDefault(c => c.Barcode == model.Barcode);
            if (userbarcode is not null)
                return new AuthModel() { Massage = "this User already exits" };

            var plan = _context.GymPlans.FirstOrDefault(c => c.PlanId == model.planId);
            var member = _mapper.Map<Member>(model);
            member.Membership = new Membership()
            {
                Member = member,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(plan.DurationInDays),
            };
            member.LastAttendanceDate = DateTime.UtcNow;
            member.JoinDate = DateTime.UtcNow;
            var paymet = new Payment()
            {
                Amount = model.price,
                CreatedById = model.userId,
                Description = "اشتراك جديد",
                PaymentDate = DateTime.UtcNow,




            };

            var result = await _userManager.CreateAsync(member, model.Barcode);
            if (result.Succeeded)
            {
                if (model.price < plan.Price)
                {
                    var Debt = new Debt()
                    {
                        Amount = plan.Price - model.price,
                        DebtDate = DateTime.UtcNow,
                        Description = "مديونية اشتراك جديد",
                        Member = member
                    };
                    _context.Add(Debt);
                    _context.SaveChanges();
                }
                return new AuthModel() { Massage = null };
            }




            return new AuthModel() { Massage =string.Join(" , ",result.Errors.Select(c=>c.Description) ) };
        }




    }
}
