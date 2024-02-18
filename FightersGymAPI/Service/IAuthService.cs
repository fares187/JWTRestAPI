using FightersGymAPI.Models;
using FightersGymAPI.ViewModel;

namespace FightersGymAPI.Service
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> getTokenAsync(TokenRequestModel model);
        Task<AuthModel> RegisterMemberAsync(RegisterMemberModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
