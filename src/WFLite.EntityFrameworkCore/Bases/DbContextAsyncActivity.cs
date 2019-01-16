/*
 * DbContextAsyncActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WFLite.Activities;

namespace WFLite.EntityFrameworkCore.Bases
{
    public abstract class DbContextAsyncActivity<TDbContext> : AsyncActivity
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public DbContextAsyncActivity(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected sealed override Task<bool> run(CancellationToken cancellationToken)
        {
            return run(_dbContext, cancellationToken);
        }

        protected abstract Task<bool> run(TDbContext dbContext, CancellationToken cancellationToken);
    }
}