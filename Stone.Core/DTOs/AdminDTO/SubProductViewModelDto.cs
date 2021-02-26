using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stone.Core.DTOs.AdminDTO
{
    public class SubProductViewModelDto
    {
        [Key]
        public int SubProductId { get; set; }

        public int ProductId { get; set; }

        //[Display(Name = "عنوان سنگ")]
        //[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        //[MaxLength(20, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        public string SubProductTitle { get; set; }

        //[Display(Name = "طول سنگ")]
        //[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        //[MaxLength(20, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        public string Length { get; set; }

        //[Display(Name = "عرض سنگ")]
        //[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        //[MaxLength(20, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        public string Width { get; set; }

        //[Display(Name = "ارتفاع سنگ")]
        //[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        //[MaxLength(20, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        public string height { get; set; }



        //[Display(Name = "قیمت سنگ")]
        //[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        //[MaxLength(20, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        public string SubProductPrice { get; set; }

        //[Display(Name = "تخفیف قیمت سنگ")]
        //[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        //[MaxLength(20, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        public string SubProductPriceDiscount { get; set; }

        //[Display(Name = "تصویر زیر محصول")]
        //[FileExtensions(Extensions = "jpg")]
        //[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public byte[] SubProductImage { get; set; }

        //[Display(Name = "توصیحات سنگ")]
        //[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        //[MaxLength(200, ErrorMessage = "{0} نباید بیشتر از  {1} کاراکتر باشد")]
        public string SubProductDescription { get; set; }

    }
}
