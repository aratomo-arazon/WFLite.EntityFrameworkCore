using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WFLite.EntityFrameworkCore.HelloWorld.Contexts;
using WFLite.EntityFrameworkCore.Bases;

namespace WFLite.EntityFrameworkCore.HelloWorld.Conditions
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
