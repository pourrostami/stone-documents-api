using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stone.Core.DTOs.AdminDTO
{
    public class ProductImageViewModelDto
    {
        [Key]
        public int ProductImageID { get; set; }

        public int SubProductId { get; set; }

        public byte[] Image { get; set; }
    }
}
