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
        private readonly Func<bool> _func;

        public DbContextCondition(TDbContext dbContext)
        {
            _func = () => check(dbContext);
        }

        public DbContextCondition(Func<TDbContext> dbContextFunc)
        {
            _func = () =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return check(dbContext);
                }
            };
        }

        public DbContextCondition(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _func = () => check(dbContext);
        }

        public DbContextCondition(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _func = () =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return check(dbContext);
                }
            };
        }

        protected sealed override bool check()
        {
            return _func();
        }

        protected abstract bool check(TDbContext dbContext);
    }
}