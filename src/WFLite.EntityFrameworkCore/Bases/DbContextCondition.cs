/*
 * DbContextCondition.cs
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
    public abstract class DbContextCondition<TDbContext> : Condition
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public DbContextCondition(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected sealed override bool check()
        {
            return check(_dbContext);
        }

        protected abstract bool check(TDbContext dbContext);
    }
}