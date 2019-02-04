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
using System;
using WFLite.Logging.Bases;

namespace WFLite.EntityFrameworkCore.Bases
{
    public abstract class DbContextCondition<TDbContext> : LoggingCondition
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextCondition(TDbContext dbContext, ILogger logger = null)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextCondition(Func<TDbContext> dbContextFunc, ILogger logger = null)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override bool check(ILogger logger)
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    return check(logger, dbContext);
                }
            }
            else
            {
                return check(logger, _dbContext);
            }
        }

        protected abstract bool check(ILogger logger, TDbContext dbContext);
    }
}