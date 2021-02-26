using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.DataLayer.Entities.Product
{
    public class CustomerProduct
    {
        public int CustomerProductId { get; set; }
        public string DeceasedName { get; set; }
        public DateTime DeceasedDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string MemorialSentence { get; set; }

    }
}
