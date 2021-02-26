using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stone.Core.DTOs.UserDTO
{
    public class AdminViewModelDto
    {
        [Display(Name = "موبایل")]
        public string Mobile { get; set; }

        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        public string Token { get; set; }

    }
}
