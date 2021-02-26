using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stone.Core.DTOs.AdminDTO
{
    public class ProductViewModelDto
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "عنوان محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(80, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        public string ProductTitle { get; set; }

        [Display(Name = "تصویر محصول")]
        public byte[] ProductImage { get; set; }

        [Display(Name = "قیمت شروع")]
        [MaxLength(20, ErrorMessage = "{0} نباید بیشتر از {1} کاراکتر باشد")]
        public string StartingPrice { get; set; }

        [Display(Name = "توضیحات سنگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        public string ProductDescription { get; set; }

    }
}


   