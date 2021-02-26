using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stone.DataLayer.Entities.Product
{
    public class ProductImage
    {
        public ProductImage(){}
        [Key]
        public int ProductImageID { get; set; }

        public int SubProductId { get; set; }

        public byte[] Image { get; set; }


        #region Relation
        public SubProduct subProduct { get; set; }

        #endregion
    }
}
