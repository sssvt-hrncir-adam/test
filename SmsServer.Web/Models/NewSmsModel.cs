using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SmsServer.Web.Models
{
    public class NewSmsModel
    {
        [Description("Phone number")]
        public string PhoneNumber { get; set; }

        [Description("Text")]
        public string Text { get; set; }        
    }
}
