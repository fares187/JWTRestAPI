using FightersGymAPI.Models;
using FightersGymAPI.ViewModel;

namespace FightersGymAPI.Service
{
    public interface IManagementService
    {
        Task<AuthModel> RecordAttendance(AttendanceViewModel model);
        Task<AuthModel> RegisterNewMember(NewMemberViewModel model);
        //Task<AuthModel> RegisterNewMember(RegisterModel model);
        //Task<AuthModel> RecordExpenses(RegisterModel model);
        //Task<AuthModel> RecordPayment(RegisterModel model);
        //Task<AuthModel> RegisterNewTrainee(RegisterModel model);

    }
}
