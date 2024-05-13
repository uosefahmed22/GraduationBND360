﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.BusinessDto
{
    public class BusinessContactDto
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Url { get; set; }
    }
}
