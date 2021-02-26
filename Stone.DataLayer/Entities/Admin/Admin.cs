using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stone.DataLayer.Entities.Admin
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(11, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        [Phone(ErrorMessage = "{0} وارد شده صحیح نمیباشد!")]
        public string Mobile { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(20, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        [MinLength(4, ErrorMessage = "{0} نباید کمتر از  {1} کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(30, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "{0} وارد شده صحیح نمیباشد!")]
        public string Email { get; set; }

    }
}
