using FightersGymAPI.Models;
using FightersGymAPI.Service;
using FightersGymAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FightersGymAPI.Controllers
{
    [Route("api/[controller]")]
   
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.RegisterAsync(model);
            if (!result.IsAuthenticated)
                return BadRequest(result.Massage);    
            return Ok(result);
        }
        [HttpPost("registerMember")]
        public async Task<IActionResult> RegisterMemeberAsync([FromBody] RegisterMemberModel model)
        {
            if (!ModelState.IsValid)
            {
                string ere = "";
                foreach (var modelState in ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        ere += error.ErrorMessage + " ";
                    }
                }

                return Ok(new AuthModel() { Massage = ere });

            }
            var result = await _authService.RegisterMemberAsync(model);
            if (!result.IsAuthenticated)
                return Ok(new AuthModel
                {
                    Massage = result.Massage
                });
            return Ok(result);
        }

        [HttpPost("token")]
        public async Task<IActionResult> getTokenAsync([FromBody]  TokenRequestModel model)
        {

            if (!ModelState.IsValid)
            {
                string ere = "";
                foreach (var modelState in ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        ere += error.ErrorMessage +" ";
                    }
                }
                
                return Ok(new AuthModel() { Massage = ere});

            }
               
            var result = await _authService.getTokenAsync(model);
            if (!result.IsAuthenticated)
                return Ok(result);
            return Ok(result);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("addusertorole")]

        public async Task<IActionResult> AddUserToRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.AddRoleAsync(model);
            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);
            return Ok("User has been assigned to the Role successfully");
        }
    }
}
