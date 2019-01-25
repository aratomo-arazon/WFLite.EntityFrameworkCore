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
using WFLite.Bases;
using WFLite.Logging.Bases;

namespace WFLite.EntityFrameworkCore.Bases
{
    public abstract class DbContextCondition<TDbContext> : Condition
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextCondition(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContextCondition(Func<TDbContext> dbContextFunc)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override bool check()
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    return check(dbContext);
                }
            }
            else
            {
                return check(_dbContext);
            }
        }

        protected abstract bool check(TDbContext dbContext);
    }

    public abstract class DbContextCondition<TCategoryName, TDbContext> : LoggingCondition<TCategoryName>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextCondition(ILogger<TCategoryName> logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextCondition(ILogger<TCategoryName> logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override bool check(ILogger<TCategoryName> logger)
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    return check(logger, dbContext);
                }
            }
            else
            {
                return check(logger, _dbContext);
            }
        }

        protected abstract bool check(ILogger<TCategoryName> logger, TDbContext dbContext);
    }
}