using Stone.Core.Services.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Core.Services.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
