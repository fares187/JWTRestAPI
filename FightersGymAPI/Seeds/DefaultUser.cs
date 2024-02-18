using CsvHelper.Configuration;
using FightersGymAPI.Models;
using FightersGymAPI.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using FightersGymAPI.Models.added;
using FightersGymAPI.Const;
using static System.Runtime.InteropServices.JavaScript.JSType;
using FightersGymAPI.data;
using System.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.EntityFrameworkCore;

namespace FightersGymAPI.Seeds
{
    public static class DefaultUser
    {
        /*
        public static async Task SeedUsersAcync(UserManager<ApplicationUser> UserManager)
        {
            //if (!UserManager.Users.Any())
            //{
                //    ApplicationUser user = new ()
                //    {
                //        UserName="marco34",
                //        Email="admim@bookify.com",
                //      //  FullName = "marco",
                //        EmailConfirmed = true,

                //    };
                //    var result =await UserManager.CreateAsync(user,"P@ssword121");
                //    if (result.Succeeded)
                //    {
                ////        await UserManager.AddToRoleAsync(user,AppRoles.Admin);
                //    }
                #region new 
                var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                };

                using (var reader = new StreamReader("C:/Users/Fares/Documents/gym/New folder/csv/New folder/Memebers.csv"))
                {
                    using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                          var records = csv.GetRecords<SeedingMemebersViewModel>();
                        int i = 1;
                        foreach (var record in records)
                        {
                        var user = new Member()
                        {
                            //UserName = ,
                            //Email = model.Email,
                            //Barcode = model.Barcode,
                            //Address = model.Address,
                            //BirthDate = model.BirthDate,
                            //DaysLeft = model.DaysLeft,
                            //Gender = model.Gender,
                            //JoinDate = model.JoinDate,
                            //FirstName = model.FirstName,
                            //LastName = model.LastName,
                            //ProfilePic = model.ProfilePic,
                            //Phone = model.Phone,
                            //PhoneNumber = model.Phone,

                            FirstName = record.FirstName,
                            UserName = record.Barcode,
                            LastName = record.LastName,
                            Address = record.Address,
                            Barcode = record.Barcode,
                            Phone = string.IsNullOrEmpty(record.Phone) ? $"111{i}" : record.Phone,
                            PhoneNumber = string.IsNullOrEmpty(record.Phone) ? $"111{i}" : record.Phone,
                            BirthDate = record.BirthDate.HasValue ? record.BirthDate.Value : null,
                            DaysLeft = record.DaysLeft,
                            Email = string.IsNullOrEmpty(record.Email) ? $"nullEmail{i}@gmail.com" : record.Email,
                            Gender = record.Gender,
                            JoinDate =record.JoinDate.HasValue? DateTime.SpecifyKind(record.JoinDate!.Value, DateTimeKind.Utc):null,
                            LastAttendanceDate = DateTime.SpecifyKind(record.LastAttendanceDate, DateTimeKind.Utc) ,
                            ProfilePic = record.ProfilePic,

                            };

                            var result = await UserManager.CreateAsync(user, record.Barcode);
                            if (!result.Succeeded)
                            {
                                Console.WriteLine(record.Barcode);
                                continue;
                            }
                            await UserManager.AddToRoleAsync(user, GymRoles.Trainee);
                        i++;
                        }
                    };
                };

                #endregion
            //}
        }
       */
        /*
        public static async Task SeedAttendaceAcync(ApplicationDbContext context)
        {

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            using (var reader = new StreamReader("C:/Users/Fares/Documents/gym/New folder/csv/Attendance.csv"))
            {
                using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<AttendaceSeedingModel>();
                    int i = 1;
                    string barcodes = "";
                    foreach (var record in records)
                    {
                        try
                        {
                            Debug.WriteLine( "------------------>tree");
                            var mem = context.Members.SingleOrDefault(m => m.Barcode == record.Barcode.ToString());
                            if (mem is null)
                            {
                                Debug.WriteLine($"------------------>barcode {record.Barcode} do not exist");
                                barcodes += record.Barcode.ToString() + " ,";
                                Debug.WriteLine("-+-+-+-+->missingbars is " + barcodes);
                                continue;
                            }
                            var attendance = new Attendance()
                            {
                                AttednaceId = record.AttendanceID,
                                MemberId = mem.Id,
                                BarCode = record.Barcode,
                                Datetime = DateTime.SpecifyKind(record.AttendanceDate, DateTimeKind.Utc),
                            };
                            context.Add(attendance);
                            context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString() + "-------------->" + record.Barcode);
                        }



                    }
                };
            };


        }
        */
        /*

        public static async Task SeedDebtAcync(ApplicationDbContext context)
        {

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using var memberreader = new StreamReader("C:/Users/Fares/Documents/gym/New folder/csv/New folder/Memebers.csv");


            using  var membercsv = new CsvHelper.CsvReader(memberreader, CultureInfo.InvariantCulture);

            var orginalmember = membercsv.GetRecords<SeedingMemebersViewModel>();


            using (var reader = new StreamReader("C:/Users/Fares/Documents/gym/New folder/csv/Debt.csv"))
            {
                using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<DebtSeedingModel>();

                    foreach (var record in records)
                    {
                        try
                        {


                            Debug.WriteLine("------------------>tree");
                            var id = orginalmember.SingleOrDefault(c=> c.MemberID == record.MemberID);
                            if (id is null)
                            {
                                Debug.WriteLine($"------------------>barcode {record.MemberID} do not exist");
                                
                                continue;
                            }

                            var mem = context.Members.SingleOrDefault(m => m.Barcode == id.Barcode);
                            if (mem is null)
                            {
                                Debug.WriteLine($"------------------>barcode {record.MemberID} toti do not exist");
                                
                                continue;
                            }
                            var Debt = new Debt()
                            {
                              DebtId= record.DebtId,
                              Amount= record.Amount,    
                              DebtDate = DateTime.SpecifyKind(record.DebtDate,DateTimeKind.Utc),   
                              Description= record.description,  
                              Member= mem,
                              MemeberId= mem.Id,  
                            };
                            context.Add(Debt);
                            context.SaveChanges();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString() + "--------------> there is an error" );
                        }



                    }
                };
            };


        }*/

        /*
     public static async Task SeedTrainersAcync(ApplicationDbContext context, UserManager<ApplicationUser> Usermanager)
     {

      

         using (var reader = new StreamReader("C:/Users/Fares/Documents/gym/New folder/csv/GymUsers.csv"))
         {
             using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
             {
                 var records = csv.GetRecords<SeedingUsersadd>();
                 int i = 1;
                 string barcodes = "";
                 foreach (var record in records)
                 {
                     try
                     {

                            var user = new ApplicationUser()
                            {
                                FirstName = record.UserName,
                                UserName = record.UserName,
                                Email = $"nullmainuser{i}@gmail.com",
                                NormalizedEmail = $"nullmainuser{i}@gmail.com".ToUpper(),
                                PhoneNumber=record.Passward



                            
                         };
                          var m=await  Usermanager.CreateAsync(user,record.Passward);
                            Debug.WriteLine(m.Succeeded);
                          await Usermanager.AddToRoleAsync(user,GymRoles.User);
                            i ++;
                     }
                     catch (Exception ex)
                     {
                         Console.WriteLine(ex.ToString() + "-------------->" + record.UserName);
                     }



                 }
             };
         };


     }*/

        /*
        public static async Task SeedexpensesAcync(ApplicationDbContext context, UserManager<ApplicationUser> Usermanager)
        {




            using (var reader = new StreamReader("C:/Users/Fares/Documents/gym/New folder/csv/Expenses.csv"))
            {
                using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<SeedingExpensesModel>();
                    int i = 1;
                    string barcodes = "";
                    foreach (var record in records)
                    {
                        try
                        {
                            using (var usereader = new StreamReader("C:/Users/Fares/Documents/gym/New folder/csv/GymUsers.csv"))
                            {


                                using (var usecsv = new CsvHelper.CsvReader(usereader, CultureInfo.InvariantCulture))
                                {

                                    var userrecords = usecsv.GetRecords<SeedingUsersadd>();
                                    string u = userrecords.FirstOrDefault(c => c.UserId.ToString() == record.CreatedBy)!
                                        .UserName;
                                    ApplicationUser? userfin = await Usermanager.FindByNameAsync(u);
                                    Expenses expenses = new()
                                    {
                                        Amount = record.amount,
                                        CreatedBy = userfin.Id,
                                        ApplicationUser = userfin,
                                        Description = record.description,
                                        ExpenseDate = DateTime.SpecifyKind(record.expense_date, DateTimeKind.Utc),






                                    };
                                    context.Expences.Add(expenses);
                                    context.SaveChanges();
                                    i++;
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString() + "-------------->" + record.CreatedBy);
                        }



                    }
                };
            };


        }
        */



        /*
        public static async Task SeedMembershipAcync(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            string no = "";
            using (var reader = new StreamReader("C:/Users/Fares/Documents/gym/New folder/csv/Memeberships.csv"))
            {
                using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<seedingMemberships>();

                    foreach (var record in records)
                    {
                        try
                        {
                            using (var memberreader = new StreamReader("C:/Users/Fares/Documents/gym/New folder/csv/New folder/Memebers.csv"))
                            {
                                using (var membercsv = new CsvHelper.CsvReader(memberreader, CultureInfo.InvariantCulture))
                                {


                                    var orginalmember = membercsv.GetRecords<SeedingMemebersViewModel>();


                                    var u = orginalmember.FirstOrDefault(c => c.MemberID == record.MemberID);
                                    if (u is null)
                                    {
                                        no += record.MemberID + " ,";
                                        continue;
                                    }

                                    var UserId = context.Members.FirstOrDefault(c => c.Barcode == u.Barcode);
                                    if (UserId is null)
                                    {
                                        no += " |/" + u.Barcode + " ";
                                        continue;
                                    }
                                    Membership membership = new Membership()
                                    {
                                        MembershipId = record.MembershipID,
                                        Member = UserId,
                                        Plan = context.GymPlans.SingleOrDefault(c=>c.PlanId == record.PlanID)!,
                                        EndDate = DateTime.SpecifyKind(record.EndDate, DateTimeKind.Utc),
                                        StartDate = DateTime.SpecifyKind(record.StartDate, DateTimeKind.Utc),
                                        PlanID = record.PlanID,
                                        MemberId = UserId.Id
                                    };
                                    await context.MemberShips.AddAsync(membership);
                                    await context.SaveChangesAsync();

                                }
                            }




                            //Debug.WriteLine("------------------>tree");
                            //var id = orginalmember.SingleOrDefault(c=> c.MemberID == record.MemberID);
                            //if (id is null)
                            //{
                            //    Debug.WriteLine($"------------------>barcode {record.MemberID} do not exist");

                            //    continue;
                            //}

                            //var mem = context.Members.SingleOrDefault(m => m.Barcode == id.Barcode);
                            //if (mem is null)
                            //{
                            //    Debug.WriteLine($"------------------>barcode {record.MemberID} toti do not exist");

                            //    continue;
                            //}
                            //var Debt = new Debt()
                            //{
                            //  DebtId= record.DebtId,
                            //  Amount= record.Amount,    
                            //  DebtDate = DateTime.SpecifyKind(record.DebtDate,DateTimeKind.Utc),   
                            //  Description= record.description,  
                            //  Member= mem,
                            //  MemeberId= mem.Id,  
                            //};
                            //context.Add(Debt);
                            //context.SaveChanges();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString() + "--------------> there is an error");
                        }



                    }
                    Debug.WriteLine("------------------------>"+no);
                };
            };


        }
        */


        public static async Task SeedPaymentAcync(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            string no = "";
            using (var reader = new StreamReader("C:/Users/Fares/Documents/gym/New folder/csv/New folder/Payments.csv"))
            {
                using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<SeedingPaymentsModel>();

                    foreach (var record in records)
                    {
                        try
                        {
                            using (var memberreader = new StreamReader("C:/Users/Fares/Documents/gym/New folder/csv/New folder/Memebers.csv"))
                            {
                                using (var membercsv = new CsvHelper.CsvReader(memberreader, CultureInfo.InvariantCulture))
                                {


                                    var orginalmember = membercsv.GetRecords<SeedingMemebersViewModel>();

                                    using (var Userreader = new StreamReader("C:/Users/Fares/Documents/gym/New folder/csv/GymUsers.csv"))
                                    {
                                        using (var Usercsv = new CsvHelper.CsvReader(Userreader, CultureInfo.InvariantCulture))
                                        {

                                            var gymusers = Usercsv.GetRecords<SeedingUsersadd>();

                                            var member = orginalmember.FirstOrDefault(c=>c.MemberID==record.MemberID);

                                            if (member is null)
                                            {
                                                no += record.MemberID+" ,";
                                                continue;

                                            }
                                            var user = await context.Members.FirstOrDefaultAsync(c=>c.Barcode == member.Barcode);
                                            if (user is null)
                                            {

                                                no += "/| "+member.Barcode+" ,";
                                                continue;
                                            }
                                            var gymuser = await userManager.FindByNameAsync(gymusers.FirstOrDefault(c=>c.UserId== record.CreatedBy).UserName);

                                            Payment payment = new()
                                            {
                                                PaymentDate = DateTime.SpecifyKind(record.PaymentDate,DateTimeKind.Utc),
                                                Amount = record.Amount.Value,
                                                Description=record.description,
                                                ProductId=null,
                                                MemberId=user.Id,
                                                CreatedById= gymuser is null ? "59a87014-9f21-412a-bffb-876643e44f29": gymuser.Id, 





                                            };
                                            await context.AddAsync(payment);
                                            await context.SaveChangesAsync();

                                        }
                                    }


                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString() + "--------------> there is an error");
                        }



                    }
                    Debug.WriteLine("------------------------>" + no);
                };
            };


        }

    }
}
