using FightersGymAPI.Models;
using FightersGymAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FightersGymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost("token")]
        public async Task<IActionResult> getTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.getTokenAsync(model);
            if (!result.IsAuthenticated)
                return BadRequest(result.Massage);
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
