/*
 * DbContextConverter.cs
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
    public abstract class DbContextConverter<TDbContext> : LoggingConverter
        where TDbContext : DbContext
    {
        private readonly Func<object, object> _func;

        public DbContextConverter(TDbContext dbContext)
        {
            _func = (value) => convert(dbContext, value);
        }

        public DbContextConverter(Func<TDbContext> dbContextFunc)
        {
            _func = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return convert(dbContext, value);
                }
            };
        }

        public DbContextConverter(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _func = (value) => convert(dbContext, value);
        }

        public DbContextConverter(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _func = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return convert(dbContext, value);
                }
            };
        }

        protected sealed override object convert(object value)
        {
            return _func(value);
        }

        protected abstract object convert(TDbContext dbContext, object value);
    }

    public abstract class DbContextConverter<TDbContext, TValue> : LoggingConverter<TValue>
        where TDbContext : DbContext
    {
        private readonly Func<object, TValue> _func;

        public DbContextConverter(TDbContext dbContext)
        {
            _func = (value) => convert(dbContext, value);
        }

        public DbContextConverter(Func<TDbContext> dbContextFunc)
        {
            _func = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return convert(dbContext, value);
                }
            };
        }

        public DbContextConverter(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _func = (value) => convert(dbContext, value);
        }

        public DbContextConverter(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _func = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return convert(dbContext, value);
                }
            };
        }

        protected sealed override TValue convert(object value)
        {
            return _func(value);
        }

        protected abstract TValue convert(TDbContext dbContext, object value);
    }

    public abstract class DbContextConverter<TDbContext, TInValue, TOutValue> : LoggingConverter<TInValue, TOutValue>
        where TDbContext : DbContext
    {
        private readonly Func<TInValue, TOutValue> _func;

        public DbContextConverter(TDbContext dbContext)
        {
            _func = (value) => convert(dbContext, value);
        }

        public DbContextConverter(Func<TDbContext> dbContextFunc)
        {
            _func = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return convert(dbContext, value);
                }
            };
        }

        public DbContextConverter(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _func = (value) => convert(dbContext, value);
        }

        public DbContextConverter(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _func = (value) =>
            {
                using (var dbContext = dbContextFunc())
                {
                    return convert(dbContext, value);
                }
            };
        }

        protected sealed override TOutValue convert(TInValue value)
        {
            return _func(value);
        }

        protected abstract TOutValue convert(TDbContext dbContext, TInValue value);
    }
}
