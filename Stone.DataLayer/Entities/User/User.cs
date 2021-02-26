using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stone.DataLayer.Entities.User
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name ="نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(30,ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
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

        [Display(Name = "فعال/غیرفعال")]
        public bool IsAtive { get; set; }

        [Display(Name = " کد فعال سازی")]
        public string AvtiveCode { get; set; }

        [Display(Name = "تاریخ عضویت")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "مسدود/نامسدود")]
        public bool UserBan { get; set; }

    }
}
