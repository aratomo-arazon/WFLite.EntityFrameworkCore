using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Activities.Console;
using WFLite.EntityFrameworkCore.HelloWorld.Activities;
using WFLite.EntityFrameworkCore.HelloWorld.Conditions;
using WFLite.EntityFrameworkCore.HelloWorld.Contexts;
using WFLite.EntityFrameworkCore.HelloWorld.Entities;
using WFLite.EntityFrameworkCore.HelloWorld.Variables;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.EntityFrameworkCore.HelloWorld
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<MessageDbContext>()
                .UseInMemoryDatabase("Test")
                .Options;

            using (var dbContext = new MessageDbContext(options))
            {
                var activity = new SequenceActivity()
                {
                    Activities = new List<IActivity>()
                    {
                        new IfActivity()
                        {
                            Condition = new MessageAnyCondition(dbContext),
                            Else = new InsertMessageActivity(dbContext)
                            {
                                Message = new AnyVariable() { Value = "Hello World!" }
                            }
                        },
                        new ConsoleWriteLineActivity()
                        {
                            Value = new MessageValueVariable(dbContext)
                        }
                    }
                };

                await activity.Start();
            }

            Console.ReadKey();
        }
    }
}
