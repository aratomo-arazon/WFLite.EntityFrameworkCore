/*
 * DbContextConverter.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */
 
using Microsoft.EntityFrameworkCore;

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
}
