using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WFLite.EntityFramework.HelloWorld.Contexts;
using WFLite.EntityFramework.HelloWorld.Entities;
using WFLite.EntityFrameworkCore.Bases;

namespace WFLite.EntityFramework.HelloWorld.Variables
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
