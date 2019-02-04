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
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextAsyncActivity(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextAsyncActivity(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override Task<bool> run(ILogger logger, CancellationToken cancellationToken)
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

        protected abstract Task<bool> run(ILogger logger, TDbContext dbContext, CancellationToken cancellationToken);
    }
}