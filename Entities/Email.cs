using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Email : IEntity
    {
        public int id { get; set; }
        public string EmailName { get; set; }
    }
}
