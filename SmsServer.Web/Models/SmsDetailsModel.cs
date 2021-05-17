using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmsServer.Web.Models
{
    public class SmsDetailsModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }

        [Display(Name = "Status")]
        public int Status { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Sent at")]
        public DateTime? SentAt { get; set; }
    }
}
