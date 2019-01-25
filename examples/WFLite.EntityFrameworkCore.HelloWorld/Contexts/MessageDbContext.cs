using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.EntityFrameworkCore.HelloWorld.Entities;

namespace WFLite.EntityFrameworkCore.HelloWorld.Contexts
{
    public class MessageDbContext : DbContext
    {
        public MessageDbContext(DbContextOptions<MessageDbContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages
        {
            get;
            set;
        }
    }
}
