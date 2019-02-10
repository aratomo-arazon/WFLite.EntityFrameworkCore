using System;
using System.Collections.Generic;
using System.Text;
using WFLite.EntityFrameworkCore.HelloWorld.Contexts;
using WFLite.EntityFrameworkCore.HelloWorld.Entities;
using WFLite.EntityFrameworkCore.Bases;
using WFLite.Interfaces;
using Microsoft.Extensions.Logging;

namespace WFLite.EntityFrameworkCore.HelloWorld.Activities
{
    public class InsertMessageActivity : DbContextSyncActivity<MessageDbContext>
    {
        public IOutVariable<string> Message
        {
            private get;
            set;
        }

        public InsertMessageActivity(MessageDbContext dbContext)
            : base(null, dbContext)
        {
        }

        public InsertMessageActivity(MessageDbContext dbContext, IOutVariable<string> message)
            : base(null, dbContext)
        {
            Message = message;
        }

        protected sealed override bool run(MessageDbContext dbContext)
        {
            dbContext.Messages.Add(new Message()
            {
                Value = Message.GetValue()
            });
            dbContext.SaveChanges();

            return true;
        }
    }
}
