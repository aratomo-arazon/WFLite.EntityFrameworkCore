/*
 * DbContextVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using Microsoft.EntityFrameworkCore;
using WFLite.Bases;

namespace WFLite.EntityFrameworkCore.Bases
{
    public abstract class DbContextVariable<TDbContext> : Variable
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public DbContextVariable(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected sealed override object getValue()
        {
            return getValue(_dbContext);
        }

        protected sealed override void setValue(object value)
        {
            setValue(_dbContext, value);
        }

        protected abstract object getValue(TDbContext dbContext);

        protected abstract void setValue(TDbContext dbContext, object value);
    }
}