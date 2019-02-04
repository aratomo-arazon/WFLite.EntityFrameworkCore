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
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextConverter(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextConverter(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override object convert(ILogger logger, object value)
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    return convert(dbContext, logger, value);
                }
            }
            else
            {
                return convert(_dbContext, logger, value);
            }
        }

        protected abstract object convert(TDbContext dbContext, ILogger logger, object value);
    }

    public abstract class DbContextConverter<TDbContext, TValue> : LoggingConverter<TValue>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextConverter(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextConverter(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override TValue convert(ILogger logger, object value)
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    return convert(dbContext, logger, value);
                }
            }
            else
            {
                return convert(_dbContext, logger, value);
            }
        }

        protected abstract TValue convert(TDbContext dbContext, ILogger logger, object value);
    }

    public abstract class DbContextConverter<TDbContext, TInValue, TOutValue> : LoggingConverter<TInValue, TOutValue>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextConverter(ILogger logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextConverter(ILogger logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override TOutValue convert(ILogger logger, TInValue value)
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    return convert(dbContext, logger, value);
                }
            }
            else
            {
                return convert(_dbContext, logger, value);
            }
        }

        protected abstract TOutValue convert(TDbContext dbContext, ILogger logger, TInValue value);
    }
}
