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
using WFLite.Bases;
using WFLite.Interfaces;
using WFLite.Logging.Bases;

namespace WFLite.EntityFrameworkCore.Bases
{
    public abstract class DbContextVariable<TDbContext> : Variable
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextVariable(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContextVariable(TDbContext dbContext, IConverter converter = null)
        {
            _dbContext = dbContext;
            Converter = converter;  // TODO
        }

        public DbContextVariable(Func<TDbContext> dbContextFunc)
        {
            _dbContextFunc = dbContextFunc;
        }

        public DbContextVariable(Func<TDbContext> dbContextFunc, IConverter converter = null)
        {
            _dbContextFunc = dbContextFunc;
            Converter = converter;  // TODO
        }

        protected sealed override object getValue()
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    return getValue(dbContext);
                }
            }
            else
            {
                return getValue(_dbContext);
            }
        }

        protected sealed override void setValue(object value)
        {
            if (_dbContextFunc != null)
            {
                using (var dbContext = _dbContextFunc())
                {
                    setValue(dbContext, value);
                }
            }
            else
            {
                setValue(_dbContext, value);
            }
        }

        protected abstract object getValue(TDbContext dbContext);

        protected abstract void setValue(TDbContext dbContext, object value);
    }

    public abstract class DbContextVariable<TCategoryName, TDbContext> : LoggingVariable<TCategoryName>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        private readonly Func<TDbContext> _dbContextFunc;

        public DbContextVariable(ILogger<TCategoryName> logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        public DbContextVariable(ILogger<TCategoryName> logger, TDbContext dbContext, IConverter converter = null)
            : base(logger)
        {
            _dbContext = dbContext;
            Converter = converter;  // TODO
        }

        public DbContextVariable(ILogger<TCategoryName> logger, Func<TDbContext> dbContextFunc)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
        }

        public DbContextVariable(ILogger<TCategoryName> logger, Func<TDbContext> dbContextFunc, IConverter converter = null)
            : base(logger)
        {
            _dbContextFunc = dbContextFunc;
            Converter = converter;  // TODO
        }

        protected sealed override object getValue(ILogger<TCategoryName> logger)
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

        protected sealed override void setValue(ILogger<TCategoryName> logger, object value)
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

        protected abstract object getValue(ILogger<TCategoryName> logger, TDbContext dbContext);

        protected abstract void setValue(ILogger<TCategoryName> logger, TDbContext dbContext, object value);
    }
}