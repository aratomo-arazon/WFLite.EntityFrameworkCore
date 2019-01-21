/*
 * DbContextAsyncActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Logging.Bases;

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

    public abstract class DbContextAsyncActivity<TCategoryName, TDbContext> : LoggingAsyncActivity<TCategoryName>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public DbContextAsyncActivity(ILogger<TCategoryName> logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        protected sealed override Task<bool> run(ILogger<TCategoryName> logger, CancellationToken cancellationToken)
        {
            return run(logger, _dbContext, cancellationToken);
        }

        protected abstract Task<bool> run(ILogger<TCategoryName> logger, TDbContext dbContext, CancellationToken cancellationToken);
    }
}