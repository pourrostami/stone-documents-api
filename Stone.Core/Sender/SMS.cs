using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kavenegar;

namespace Stone.Core.Sender
{
    public class SMS
    {
        public async Task<bool> Send(string reciver, string body)
        {
            var sender = "1000596446";
            var receptor = reciver;
            var message = body;
            var api = new KavenegarApi
            ("436F494C63434D454F507A45524A39347830427A4F706C4B354852744357313362767442486E6232564D4D3D");
            var a = api.Send (sender, receptor, message);
            if (a.Status==1)
                return true;
            return false;
        }

    }
}
