﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MMLib.Extensions;
using Payroll.Common;
using Payroll.Data;
using Payroll.Models;

namespace Payroll.Business
{
    public class OccupationsBO: GenericBO<Occupation>
    {
        public OccupationsBO(ApplicationDbContext context): base(context) {}

        public override Expression<Func<Occupation, object>> GetOrder()
        {
            return a => a.Name;
        }

        public override IQueryable<Occupation> BaseQuery(string filter)
        {
            return _context.Occupation
                .Where(a => !a.Deleted)
                .Where(a => string.IsNullOrEmpty(filter) ||
                (a.Name.RemoveDiacritics().Contains(filter.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase) ||
                (a.CouncilName != null && a.CouncilName.Contains(filter, StringComparison.InvariantCultureIgnoreCase))));
        }

        public override async Task<Occupation> Find(Guid? id)
        {
            return await _context.Occupation
                .Where(a => !a.Deleted)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
