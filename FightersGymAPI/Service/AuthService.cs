using FightersGymAPI.Helper;
using FightersGymAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NuGet.Packaging.Signing;
using System.Diagnostics;
using System.Formats.Asn1;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace FightersGymAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly JWT _jwt;
        public AuthService(UserManager<ApplicationUser> userManager, IOptions<JWT> wt, RoleManager<IdentityRole> roleManager)
        {
            _jwt = wt.Value;
            _userManager = userManager;
            _RoleManager = roleManager;
        }

        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user =await _userManager.FindByIdAsync(model.UserId);
            if (user is null)
                return "Invalid user Id";

            if (!await _RoleManager.RoleExistsAsync(model.RoleName))
                return "This role do not exist";
            if (await _userManager.IsInRoleAsync(user, model.RoleName))
                return "the user already assigned to this role";

           var result= await _userManager.AddToRoleAsync(user, model.RoleName);
            if (result.Succeeded)
                return string.Empty;
            return "something went wrong";
        }

        public async Task<AuthModel> getTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();
            var user =await _userManager.FindByNameAsync(model.UserName);
            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Massage = "Email or Password in not correct";
                return authModel;
            }
          authModel.IsAuthenticated=true;
            var jwtscuritytoken = await CreateJwtToken(user);
            authModel.token = new JwtSecurityTokenHandler().WriteToken(jwtscuritytoken);
            authModel.ExpiresOn = jwtscuritytoken.ValidTo;
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            var RolesList = await _userManager.GetRolesAsync(user);
            authModel.Roles=RolesList.ToList();
            return authModel;
        }

        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {

            if (await _userManager.FindByNameAsync(model.UserName) is not null)
            {
                return new AuthModel { Massage = "This user name is already Registered" };
            }
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                return new AuthModel { Massage = "This Email is already Registered" };
            }
            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                string errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors = errors + ",\n" + error.Description;
                }
                return new AuthModel() { Massage = errors };
            }
            await _userManager.AddToRoleAsync(user, "User");
            var jwtscuritytoken = await CreateJwtToken(user);
            return new AuthModel()
            {
                Email = user.Email,
                Username = user.UserName,
                ExpiresOn = jwtscuritytoken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                token = new JwtSecurityTokenHandler().WriteToken(jwtscuritytoken)
            };
        }
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays((int)_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
