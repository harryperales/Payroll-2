﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payroll.Business;
using Payroll.Common;
using Payroll.Models;

namespace Payroll.Controllers
{
    public class FunctionsController : GenericController<Function>
    {
        public FunctionsController(BusinessObject<Function> businessObject, Message message)
            :base(businessObject, message) { }


        public override Task<IActionResult> Index(int page = 1, string filter = "", string sort = "", string order = "ASC")
        {
            ViewBag.Companies = Utils
                .GetOptions(_businessObject
                .GetDAO()
                .GetContext()
                .Company
                .Where(a => !a.IsDeleted));

            return base.Index(page, filter, sort, order);
        }

    }
}