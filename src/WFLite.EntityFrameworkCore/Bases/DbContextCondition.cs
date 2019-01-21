/*
 * DbContextCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WFLite.Bases;
using WFLite.Logging.Bases;

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

    public abstract class DbContextCondition<TCategoryName, TDbContext> : LoggingCondition<TCategoryName>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public DbContextCondition(ILogger<TCategoryName> logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        protected sealed override bool check(ILogger<TCategoryName> logger)
        {
            return check(logger, _dbContext);
        }

        protected abstract bool check(ILogger<TCategoryName> logger, TDbContext dbContext);
    }
}