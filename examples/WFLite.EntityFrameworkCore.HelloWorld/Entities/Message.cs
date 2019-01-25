using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WFLite.EntityFrameworkCore.HelloWorld.Entities
{
    public class Message
    {
        [Key]
        public int Id
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }
}
