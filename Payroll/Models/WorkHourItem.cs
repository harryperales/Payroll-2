﻿using Payroll.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Payroll.Models
{
    public class WorkHourItem
    {
        public Guid WorkHourItemId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(Resource), Name = "DayOfWeek")]
        public Common.DayOfWeek DayOfWeek { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(Resource), Name = "Start")]
        public TimeSpan Start { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(Resource), Name = "End")]
        public TimeSpan End { get; set; }

        public string DayOfWeekDescription { get { return this.DayOfWeek.GetDescription(); } }

    }
}
