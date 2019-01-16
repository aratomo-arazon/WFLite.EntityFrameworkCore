/*
 * DbContextSyncActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using Microsoft.EntityFrameworkCore;
using WFLite.Activities;

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
}