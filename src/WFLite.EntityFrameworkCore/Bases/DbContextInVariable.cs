/*
 * DbContextVariable.cs
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
    public abstract class DbContextInVariable<TDbContext> : LoggingInVariable
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextInVariable(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextInVariable(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override void setValue(ILogger logger, object value)
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    setValue(logger, dbContext, value);
                }
            }
            else
            {
                setValue(logger, _dbContext, value);
            }
        }

        protected abstract void setValue(ILogger logger, TDbContext dbContext, object value);
    }

    public abstract class DbContextInVariable<TDbContext, TInValue> : LoggingInVariable<TInValue>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextInVariable(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextInVariable(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override void setValue(ILogger logger, object value)
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    setValue(logger, dbContext, value);
                }
            }
            else
            {
                setValue(logger, _dbContext, value);
            }
        }

        protected abstract void setValue(ILogger logger, TDbContext dbContext, object value);
    }
}