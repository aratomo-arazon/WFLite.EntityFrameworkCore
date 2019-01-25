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
using WFLite.Activities;
using WFLite.Logging.Bases;

namespace WFLite.EntityFrameworkCore.Bases
{
    public abstract class DbContextSyncActivity<TDbContext> : SyncActivity
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextSyncActivity(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContextSyncActivity(Func<TDbContext> dbContextFunc)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override bool run()
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    return run(dbContext);
                }
            }
            else
            {
                return run(_dbContext);
            }
        }

        protected abstract bool run(TDbContext dbContext);
    }

    public abstract class DbContextSyncActivity<TCategoryName, TDbContext> : LoggingSyncActivity<TCategoryName>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextSyncActivity(ILogger<TCategoryName> logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextSyncActivity(ILogger<TCategoryName> logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override bool run(ILogger<TCategoryName> logger)
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    return run(logger, dbContext);
                }
            }
            else
            {
                return run(logger, _dbContext);
            }
        }

        protected abstract bool run(ILogger<TCategoryName> logger, TDbContext dbContext);
    }
}