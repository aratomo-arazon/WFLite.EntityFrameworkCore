using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WFLite.EntityFramework.HelloWorld.Contexts;
using WFLite.EntityFrameworkCore.Bases;

namespace WFLite.EntityFramework.HelloWorld.Conditions
{
    public class MessageAnyCondition : DbContextCondition<MessageDbContext>
    {
        public MessageAnyCondition(MessageDbContext dbContext)
           : base(dbContext)
        {
        }

        protected sealed override bool check(MessageDbContext dbContext)
        {
            return dbContext.Messages.Any();
        }
    }
}
