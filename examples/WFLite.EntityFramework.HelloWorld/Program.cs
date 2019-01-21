using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Activities.Console;
using WFLite.EntityFramework.HelloWorld.Activities;
using WFLite.EntityFramework.HelloWorld.Conditions;
using WFLite.EntityFramework.HelloWorld.Contexts;
using WFLite.EntityFramework.HelloWorld.Entities;
using WFLite.EntityFramework.HelloWorld.Variables;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.EntityFramework.HelloWorld
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
