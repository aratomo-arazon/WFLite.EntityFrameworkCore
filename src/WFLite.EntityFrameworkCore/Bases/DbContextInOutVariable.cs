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
        private readonly Func<object> _func;

        private readonly Action<object> _action;

        public DbContextInOutVariable(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _func = () => getValue(dbContext);
            _action = (value) => setValue(dbContext, value);
        }

        public DbContextInOutVariable(ILogger logger, TDbContext dbContext, IConverter converter = null)
            : base(logger, converter)
        {
            _func = () => getValue(dbContext);
            _action = (value) => setValue(dbContext, value);
        }

        public DbContextInOutVariable(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _func = () =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return getValue(dbContext);
                }
            };
            _action = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    setValue(dbContext, value);
                }
            };
        }

        public DbContextInOutVariable(ILogger logger, Func<TDbContext> dbContextFunc, IConverter converter = null)
            : base(logger, converter)
        {
            _func = () =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return getValue(dbContext);
                }
            };
            _action = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    setValue(dbContext, value);
                }
            };
        }

        protected sealed override object getValue()
        {
            return _func();
        }

        protected sealed override void setValue(object value)
        {
            _action(value);
        }

        protected abstract object getValue(TDbContext dbContext);

        protected abstract void setValue(TDbContext dbContext, object value);
    }

    public abstract class DbContextInOutVariable<TDbContext, TValue> : LoggingInOutVariable<TValue>
        where TDbContext : DbContext
    {
        private readonly Func<object> _func;

        private readonly Action<object> _action;

        public DbContextInOutVariable(TDbContext dbContext, IConverter<TValue> converter = null)
            : base(converter)
        {
            _func = () => getValue(dbContext);
            _action = (value) => setValue(dbContext, value);
        }

        public DbContextInOutVariable(Func<TDbContext> dbContextFunc, IConverter<TValue> converter = null)
            : base(converter)
        {
            _func = () =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return getValue(dbContext);
                }
            };
            _action = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    setValue(dbContext, value);
                }
            };
        }

        public DbContextInOutVariable(ILogger logger, TDbContext dbContext, IConverter<TValue> converter = null)
            : base(logger, converter)
        {
            _func = () => getValue(dbContext);
            _action = (value) => setValue(dbContext, value);
        }

        public DbContextInOutVariable(ILogger logger, Func<TDbContext> dbContextFunc, IConverter<TValue> converter = null)
            : base(logger, converter)
        {
            _func = () =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return getValue(dbContext);
                }
            };
            _action = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    setValue(dbContext, value);
                }
            };
        }

        protected sealed override object getValue()
        {
            return _func();
        }

        protected sealed override void setValue(object value)
        {
            _action(value);
        }

        protected abstract object getValue(TDbContext dbContext);

        protected abstract void setValue(TDbContext dbContext, object value);
    }

    public abstract class DbContextInOutVariable<TDbContext, TInValue, TOutValue> : LoggingInOutVariable<TInValue, TOutValue>
        where TDbContext : DbContext
    {
        private readonly Func<object> _func;

        private readonly Action<object> _action;

        public DbContextInOutVariable(TDbContext dbContext, IConverter<TInValue, TOutValue> converter = null)
            : base(converter)
        {
            _func = () => getValue(dbContext);
            _action = (value) => setValue(dbContext, value);
        }


        public DbContextInOutVariable(Func<TDbContext> dbContextFunc, IConverter<TInValue, TOutValue> converter = null)
            : base(converter)
        {
            _func = () =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return getValue(dbContext);
                }
            };
            _action = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    setValue(dbContext, value);
                }
            };
        }

        public DbContextInOutVariable(ILogger logger, TDbContext dbContext, IConverter<TInValue, TOutValue> converter = null)
            : base(logger, converter)
        {
            _func = () => getValue(dbContext);
            _action = (value) => setValue(dbContext, value);
        }


        public DbContextInOutVariable(ILogger logger, Func<TDbContext> dbContextFunc, IConverter<TInValue, TOutValue> converter = null)
            : base(logger, converter)
        {
            _func = () =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return getValue(dbContext);
                }
            };
            _action = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    setValue(dbContext, value);
                }
            };
        }

        protected sealed override object getValue()
        {
            return _func();
        }

        protected sealed override void setValue(object value)
        {
            _action(value);
        }

        protected abstract object getValue(TDbContext dbContext);

        protected abstract void setValue(TDbContext dbContext, object value);
    }
}