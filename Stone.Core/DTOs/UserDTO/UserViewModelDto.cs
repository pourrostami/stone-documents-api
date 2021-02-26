using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stone.Core.DTOs.UserDTO
{
    public class UserViewModelDto
    {
        public int UserId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(30, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(11, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        [Phone(ErrorMessage = "{0} وارد شده صحیح نمیباشد!")]
        public string Mobile { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(30, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "{0} وارد شده صحیح نمیباشد!")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(20, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        [MinLength(4, ErrorMessage = "{0} نباید کمتر از  {1} کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(20, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        [MinLength(4, ErrorMessage = "{0} نباید کمتر از  {1} کاراکتر باشد")]
        [Compare("Password", ErrorMessage = "پسورد وارد شده یکسان نیست")]
        public string RePassword { get; set; }

        [Display(Name = "فعال/غیرفعال")]
        public bool IsAtive { get; set; }

        [Display(Name = " کد فعال سازی")]
        public string AvtiveCode { get; set; }

        [Display(Name = "تاریخ عضویت")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "قوانین سایت")]
        //[Required(ErrorMessage ="قوانین {0} را تایید نکرده اید! ")]
        public bool SiteRule { get; set; }
    }

    public class CheckActiveCodeViewModelDto
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(30, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(11, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        [Phone(ErrorMessage = "{0} وارد شده صحیح نمیباشد!")]
        public string Mobile { get; set; }

        [Display(Name = " کد فعال سازی اصلی")]
        public string APIAvtiveCode { get; set; }

        [Display(Name = " کد فعال سازی ارسالی کاربر")]
        public string UserAvtiveCode { get; set; }

    }

    public class ProfileViewModelDto
    {
        public int UserId { get; set; }

        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "موبایل")]
        public string Mobile { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "تاریخ عضویت")]
        public DateTime RegisterDate { get; set; }
        
        public string Token { get; set; }

    }

    public class LoginViewModelDto
    {

        [Display(Name = "موبایل")]
        public string Mobile { get; set; }

        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
