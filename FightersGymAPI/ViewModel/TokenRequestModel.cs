﻿using System.ComponentModel.DataAnnotations;

namespace FightersGymAPI.ViewModel
{
    public class TokenRequestModel
    {

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
