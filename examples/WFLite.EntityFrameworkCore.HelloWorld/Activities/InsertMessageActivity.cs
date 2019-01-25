using System;
using System.Collections.Generic;
using System.Text;
using WFLite.EntityFrameworkCore.HelloWorld.Contexts;
using WFLite.EntityFrameworkCore.HelloWorld.Entities;
using WFLite.EntityFrameworkCore.Bases;
using WFLite.Interfaces;

namespace WFLite.EntityFrameworkCore.HelloWorld.Activities
{
    public class InsertMessageActivity : DbContextSyncActivity<MessageDbContext>
    {
        public IVariable Message
        {
            private get;
            set;
        }

        public InsertMessageActivity(MessageDbContext dbContext)
            : base(dbContext)
        {
        }

        public InsertMessageActivity(MessageDbContext dbContext, IVariable message)
            : base(dbContext)
        {
            Message = message;
        }

        protected sealed override bool run(MessageDbContext dbContext)
        {
            dbContext.Messages.Add(new Message()
            {
                Value = Message.GetValue<string>()
            });
            dbContext.SaveChanges();

            return true;
        }
    }
}
