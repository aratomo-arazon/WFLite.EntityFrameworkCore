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
    public abstract class DbContextConverter<TDbContext> : WFLite.Bases.Converter
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextConverter(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContextConverter(Func<TDbContext> dbContextFunc)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override object convert(object value)
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    return convert(dbContext);
                }
            }
            else
            {
                return convert(_dbContext, value);
            }
        }

        protected abstract object convert(TDbContext dbContext, object value);
    }

    public abstract class DbContextConverter<TCategoryName, TDbContext> : LoggingConverter<TCategoryName>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextConverter(ILogger<TCategoryName> logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextConverter(ILogger<TCategoryName> logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        protected sealed override object convert(ILogger<TCategoryName> logger, object value)
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    return convert(logger, dbContext, value);
                }
            }
            else
            {
                return convert(logger, _dbContext, value);
            }
        }

        protected abstract object convert(ILogger<TCategoryName> logger, TDbContext dbContext, object value);
    }
}
