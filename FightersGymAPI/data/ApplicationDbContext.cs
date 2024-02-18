using FightersGymAPI.Models;
using FightersGymAPI.Models.added;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System.Data;

namespace FightersGymAPI.data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Expenses> Expences { get; set; }
        public DbSet<Gymplan> GymPlans { get; set; }
        public DbSet<Membership> MemberShips { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().UseTptMappingStrategy();
            builder.Entity<Member>().ToTable("Members");
          
            //builder.Entity<Member>()
            //    .HasMany(b => b.Attendance)
            //    .WithOne()
            //    .HasForeignKey(p => p.MemberId);

            builder.Entity<Member>()
                .HasMany(M => M.Debts)
                .WithOne()
                .HasForeignKey(d => d.MemeberId);


            builder.Entity<Member>()
                .HasOne(m => m.Membership)
                .WithOne(i => i.Member)
                .HasForeignKey<Membership>(p => p.MemberId);

            //builder.Entity<Member>()
            //  .HasMany(m => m.Notification)
            //  .WithOne()
            //  .HasForeignKey(p => p.MemberId);

            builder.Entity<Member>()
              .HasMany(m => m.Payments)
              .WithOne()
              .HasForeignKey(p => p.MemberId);

            builder.Entity<ApplicationUser>()
                .HasMany(p => p.Payments)
                .WithOne(c=>c.CreatedBy)
                .HasForeignKey(p => p.CreatedById)
                .HasPrincipalKey(c=>c.Id);

            builder.Entity<ApplicationUser>()
              .HasMany(p => p.Expenses)
              .WithOne()
              .HasForeignKey(p => p.CreatedBy);

            builder.Entity<Product>()
                .HasMany(p => p.Payments)
                .WithOne(c=>c.Product)
                .HasForeignKey(p => p.ProductId)
                .HasPrincipalKey(c=>c.ProductId);

            //builder.Entity<Gymplan>()
            // .HasOne(m => m.Membership)
            // .WithOne()
            // .HasForeignKey<Membership>(p => p.PlanID);
        }
    }
}
