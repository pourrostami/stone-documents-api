using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Core.Generator
{
    public class Generator
    {
        public string AvtiveCodeGenarator()
        {
            Random random = new Random();
            return random.Next(000, 999).ToString();
        }
    }
}
