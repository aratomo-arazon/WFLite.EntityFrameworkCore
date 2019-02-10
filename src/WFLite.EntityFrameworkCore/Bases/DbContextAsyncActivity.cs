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
using WFLite.Logging.Bases;

namespace WFLite.EntityFrameworkCore.Bases
{
    public abstract class DbContextAsyncActivity<TDbContext> : LoggingAsyncActivity
        where TDbContext : DbContext
    {
        private readonly Func<CancellationToken, Task<bool>> _func;

        public DbContextAsyncActivity(TDbContext dbContext)
        {
            _func = (cancellationToken) => run(dbContext, cancellationToken);
        }

        public DbContextAsyncActivity(Func<TDbContext> dbContextFunc)
        {
            _func = (cancellationToken) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return run(dbContext, cancellationToken);
                }
            };
        }

        public DbContextAsyncActivity(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _func = (cancellationToken) => run(dbContext, cancellationToken);
        }

        public DbContextAsyncActivity(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _func = (cancellationToken) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return run(dbContext, cancellationToken);
                }
            };
        }

        protected sealed override Task<bool> run(CancellationToken cancellationToken)
        {
            return _func(cancellationToken);
        }

        protected abstract Task<bool> run(TDbContext dbContext, CancellationToken cancellationToken);
    }
}