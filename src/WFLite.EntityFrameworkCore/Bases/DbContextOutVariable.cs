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
        private readonly Func<object> _func; 

        public DbContextOutVariable(TDbContext dbContext)
        {
            _func = () => getValue(dbContext);
        }

        public DbContextOutVariable(Func<TDbContext> dbContextFunc)
        {
            _func = () =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return getValue(dbContext);
                }
            };
        }

        public DbContextOutVariable(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _func = () => getValue(dbContext);
        }

        public DbContextOutVariable(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _func = () =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return getValue(dbContext);
                }
            };
        }

        protected sealed override object getValue()
        {
            return _func();
        }

        protected abstract object getValue(TDbContext dbContext);
    }

    public abstract class DbContextOutVariable<TDbContext, TOutValue> : LoggingOutVariable<TOutValue>
        where TDbContext : DbContext
    {
        private readonly Func<object> _func;

        public DbContextOutVariable(TDbContext dbContext)
        {
            _func = () => getValue(dbContext);
        }

        public DbContextOutVariable(Func<TDbContext> dbContextFunc)
        {
            _func = () =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return getValue(dbContext);
                }
            };
        }

        public DbContextOutVariable(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _func = () => getValue(dbContext);
        }

        public DbContextOutVariable(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _func = () =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return getValue(dbContext);
                }
            };
        }

        protected sealed override object getValue()
        {
            return _func();
        }

        protected abstract object getValue(TDbContext dbContext);
    }
}