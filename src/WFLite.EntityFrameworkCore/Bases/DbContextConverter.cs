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
using WFLite.Logging.Bases;

namespace WFLite.EntityFrameworkCore.Bases
{
    public abstract class DbContextConverter<TDbContext> : WFLite.Bases.Converter
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public DbContextConverter(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected sealed override object convert(object value)
        {
            return convert(_dbContext, value);
        }

        protected abstract object convert(TDbContext dbContext, object value);
    }

    public abstract class DbContextConverter<TCategoryName, TDbContext> : LoggingConverter<TCategoryName>
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public DbContextConverter(ILogger<TCategoryName> logger, TDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
        }

        protected sealed override object convert(ILogger<TCategoryName> logger, object value)
        {
            return convert(logger, _dbContext, value);
        }

        protected abstract object convert(ILogger<TCategoryName> logger, TDbContext dbContext, object value);
    }
}
