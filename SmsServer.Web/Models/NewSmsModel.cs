﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SmsServer.Web.Models
{
    public class NewSmsModel
    {
        public string PhoneNumber { get; set; }
        public string Text { get; set; }        
    }
}
