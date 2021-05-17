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
        [Display(Name = "Phone number")]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name = "Text")]
        [Required]
        public string Text { get; set; }        
    }
}
