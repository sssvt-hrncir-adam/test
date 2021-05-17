using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsServer.Data.Enums
{
    public enum SmsStatusEnum
    {
        New = 1,
        Sent = 2,
        SendError = 3,
        ServerError = 4
    }
}
