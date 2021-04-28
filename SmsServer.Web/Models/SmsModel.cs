using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsServer.Web.Models
{
    public class SmsModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SentAt { get; set; }
    }
}
