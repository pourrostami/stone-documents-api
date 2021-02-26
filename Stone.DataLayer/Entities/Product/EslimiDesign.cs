using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stone.DataLayer.Entities.Product
{
    public class EslimiDesign
    {
        [Key]
        public int EslimiId { get; set; }

        public byte[] EslimiImage { get; set; }
    }
}
