using FightersGymAPI.Const;
using FightersGymAPI.Service;
using FightersGymAPI.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FightersGymAPI.Controllers
{
    [Route("api/[controller]")]
    public class ManagementController : ControllerBase
    {
        private IManagementService _managementService;

        public ManagementController(IManagementService managementService)
        {
            _managementService = managementService;
        }
        [Authorize(Roles =$"{GymRoles.Admin}" )]
        [HttpPost("RecordAttendance")]
        public async Task<IActionResult> RecordAttendance(AttendanceViewModel model)
        {
            if (!ModelState.IsValid) {
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
            

            var result =await _managementService.RecordAttendance(model); 
            if(!string.IsNullOrEmpty(result.Massage) )
                return Ok(result);
            return Ok();
        }



        [Authorize(Roles = $"{GymRoles.User},{GymRoles.Admin}")]
        [HttpPost("AddNewMember")]
        public async Task<IActionResult> AddNewMember(NewMemberViewModel model)
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


            var result = await _managementService.RegisterNewMember(model);
            if (!string.IsNullOrEmpty(result.Massage))
                return Ok(result);
            return Ok();
        }


    }
}
