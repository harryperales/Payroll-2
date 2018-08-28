﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll.Models
{
    public class Currency: Basic
    {
        [Display(Name="Moeda")]
        public String Name { get; set; }
        [Display(Name = "Câmbio")]
        public double Exchange { get; set; }
    }
}
