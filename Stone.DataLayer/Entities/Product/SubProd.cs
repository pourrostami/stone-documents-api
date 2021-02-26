using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stone.DataLayer.Entities.Product
{
    public class SubProd
    {
        [Key]
        public int subProdId { get; set; }

        public int ProductId { get; set; }

        public string Length { get; set; }

        public string Width { get; set; }

        public string height { get; set; }

        public string SubProductTitle { get; set; }

        public string SubProductPrice { get; set; }

        public string SubProductPriceDiscount { get; set; }

        public string SubProductDescription { get; set; }

        public byte[] SubProductImage { get; set; }

        #region Relation
        public Product product { get; set; }

        #endregion

    }
}
