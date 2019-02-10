/*
 * DbContextSyncActivity.cs
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
    public abstract class DbContextSyncActivity<TDbContext> : LoggingSyncActivity
        where TDbContext : DbContext
    {
        private readonly Func<bool> _func;

        public DbContextSyncActivity(TDbContext dbContext)
        {
            _func = () => run(dbContext);
        }

        public DbContextSyncActivity(Func<TDbContext> dbContextFunc)
        {
            _func = () =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return run(dbContext);
                }
            };
        }

        public DbContextSyncActivity(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _func = () => run(dbContext);
        }

        public DbContextSyncActivity(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _func = () =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return run(dbContext);
                }
            };
        }

        protected sealed override bool run()
        {
            return _func();
        }

        protected abstract bool run(TDbContext dbContext);
    }
}