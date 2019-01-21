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
using WFLite.Activities;
using WFLite.Logging.Bases;

namespace WFLite.EntityFrameworkCore.Bases
{
    public abstract class DbContextSyncActivity<TDbContext> : SyncActivity
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public DbContextSyncActivity(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected sealed override bool run()
        {
            return run(_dbContext);
        }

        protected abstract bool run(TDbContext dbContext);
    }

    public abstract class DbContextSyncActivity<TCategoryName, TDbContext> : LoggingSyncActivity<TCategoryName>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public DbContextSyncActivity(ILogger<TCategoryName> logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        protected sealed override bool run(ILogger<TCategoryName> logger)
        {
            return run(logger, _dbContext);
        }

        protected abstract bool run(ILogger<TCategoryName> logger, TDbContext dbContext);
    }
}