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
using WFLite.Interfaces;
using WFLite.Logging.Bases;

namespace WFLite.EntityFrameworkCore.Bases
{
    public abstract class DbContextInOutVariable<TDbContext> : LoggingInOutVariable
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextInOutVariable(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextInOutVariable(ILogger logger, TDbContext dbContext, IConverter converter = null)
            : base(logger, converter)
        {
            _dbContext = dbContext;
        }

        public DbContextInOutVariable(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        public DbContextInOutVariable(ILogger logger, Func<TDbContext> dbContextFunc, IConverter converter = null)
            : base(logger, converter)
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

        protected abstract object getValue(ILogger logger, TDbContext dbContext);

        protected abstract void setValue(ILogger logger, TDbContext dbContext, object value);
    }

    public abstract class DbContextInOutVariable<TDbContext, TValue> : LoggingInOutVariable<TValue>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextInOutVariable(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextInOutVariable(ILogger logger, TDbContext dbContext, IConverter<TValue> converter = null)
            : base(logger, converter)
        {
            _dbContext = dbContext;
        }

        public DbContextInOutVariable(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        public DbContextInOutVariable(ILogger logger, Func<TDbContext> dbContextFunc, IConverter<TValue> converter = null)
            : base(logger, converter)
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

        protected abstract object getValue(ILogger logger, TDbContext dbContext);

        protected abstract void setValue(ILogger logger, TDbContext dbContext, object value);
    }

    public abstract class DbContextInOutVariable<TDbContext, TInValue, TOutValue> : LoggingInOutVariable<TInValue, TOutValue>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextInOutVariable(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextInOutVariable(ILogger logger, TDbContext dbContext, IConverter<TInValue, TOutValue> converter = null)
            : base(logger, converter)
        {
            _dbContext = dbContext;
        }

        public DbContextInOutVariable(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        public DbContextInOutVariable(ILogger logger, Func<TDbContext> dbContextFunc, IConverter<TInValue, TOutValue> converter = null)
            : base(logger, converter)
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

        protected abstract object getValue(ILogger logger, TDbContext dbContext);

        protected abstract void setValue(ILogger logger, TDbContext dbContext, object value);
    }
}