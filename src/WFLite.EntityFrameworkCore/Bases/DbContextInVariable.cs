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
        private readonly Action<object> _action;

        public DbContextInVariable(TDbContext dbContext)
        {
            _action = (value) => setValue(dbContext, value);
        }

        public DbContextInVariable(Func<TDbContext> dbContextFunc)
        {
            _action = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    setValue(dbContext, value);
                }
            };
        }

        public DbContextInVariable(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _action = (value) => setValue(dbContext, value);
        }

        public DbContextInVariable(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _action = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    setValue(dbContext, value);
                }
            };
        }

        protected sealed override void setValue(object value)
        {
            _action(value);
        }

        protected abstract void setValue(TDbContext dbContext, object value);
    }

    public abstract class DbContextInVariable<TDbContext, TInValue> : LoggingInVariable<TInValue>
        where TDbContext : DbContext
    {
        private readonly Action<object> _action;

        public DbContextInVariable(TDbContext dbContext)
        {
            _action = (value) => setValue(dbContext, value);
        }

        public DbContextInVariable(Func<TDbContext> dbContextFunc)
        {
            _action = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    setValue(dbContext, value);
                }
            };
        }

        public DbContextInVariable(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _action = (value) => setValue(dbContext, value);
        }

        public DbContextInVariable(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _action = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    setValue(dbContext, value);
                }
            };
        }

        protected sealed override void setValue(object value)
        {
            _action(value);
        }

        protected abstract void setValue(TDbContext dbContext, object value);
    }
}