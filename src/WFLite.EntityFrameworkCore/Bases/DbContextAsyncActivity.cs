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
using System;
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

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextAsyncActivity(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContextAsyncActivity(Func<TDbContext> dbContextFunc)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override Task<bool> run(CancellationToken cancellationToken)
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    return run(dbContext, cancellationToken);
                }
            }
            else
            {
                return run(_dbContext, cancellationToken);
            }
        }

        protected abstract Task<bool> run(TDbContext dbContext, CancellationToken cancellationToken);
    }

    public abstract class DbContextAsyncActivity<TCategoryName, TDbContext> : LoggingAsyncActivity<TCategoryName>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextAsyncActivity(ILogger<TCategoryName> logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextAsyncActivity(ILogger<TCategoryName> logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override Task<bool> run(ILogger<TCategoryName> logger, CancellationToken cancellationToken)
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    return run(logger, dbContext, cancellationToken);
                }
            }
            else
            {
                return run(logger, _dbContext, cancellationToken);
            }
        }

        protected abstract Task<bool> run(ILogger<TCategoryName> logger, TDbContext dbContext, CancellationToken cancellationToken);
    }
}