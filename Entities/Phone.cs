using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Phone : IEntity
    {
        public int id { get; set; }
        public string phoneNumber { get; set; }
    }
}
