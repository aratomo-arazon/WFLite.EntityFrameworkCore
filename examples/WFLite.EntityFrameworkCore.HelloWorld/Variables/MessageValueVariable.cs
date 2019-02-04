using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WFLite.EntityFrameworkCore.HelloWorld.Contexts;
using WFLite.EntityFrameworkCore.HelloWorld.Entities;
using WFLite.EntityFrameworkCore.Bases;
using Microsoft.Extensions.Logging;

namespace WFLite.EntityFrameworkCore.HelloWorld.Variables
{
    public class MessageValueVariable : DbContextOutVariable<MessageDbContext, string>
    {
        public MessageValueVariable(MessageDbContext dbContext)
            : base(null, dbContext)
        {
        }

        protected sealed override object getValue(ILogger logger, MessageDbContext dbContext)
        {
            return dbContext.Messages.FirstOrDefault()?.Value;
        }
    }
}
