using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WFLite.EntityFrameworkCore.HelloWorld.Contexts;
using WFLite.EntityFrameworkCore.HelloWorld.Entities;
using WFLite.EntityFrameworkCore.Bases;

namespace WFLite.EntityFrameworkCore.HelloWorld.Variables
{
    public class MessageValueVariable : DbContextVariable<MessageDbContext>
    {
        public MessageValueVariable(MessageDbContext dbContext)
            : base(dbContext)
        {
        }

        protected sealed override object getValue(MessageDbContext dbContext)
        {
            return dbContext.Messages.FirstOrDefault()?.Value;
        }

        protected sealed override void setValue(MessageDbContext dbContext, object value)
        {
            throw new NotSupportedException();
        }
    }
}
