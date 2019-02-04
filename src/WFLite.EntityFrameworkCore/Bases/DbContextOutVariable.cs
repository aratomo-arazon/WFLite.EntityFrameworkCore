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
    public abstract class DbContextOutVariable<TDbContext> : LoggingOutVariable
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextOutVariable(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextOutVariable(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override object getValue(ILogger logger)
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    return getValue(logger, dbContext);
                }
            }
            else
            {
                return getValue(logger, _dbContext);
            }
        }

        protected abstract object getValue(ILogger logger, TDbContext dbContext);
    }

    public abstract class DbContextOutVariable<TDbContext, TOutValue> : LoggingOutVariable<TOutValue>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextOutVariable(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextOutVariable(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override object getValue(ILogger logger)
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    return getValue(logger, dbContext);
                }
            }
            else
            {
                return getValue(logger, _dbContext);
            }
        }

        protected abstract object getValue(ILogger logger, TDbContext dbContext);
    }
}