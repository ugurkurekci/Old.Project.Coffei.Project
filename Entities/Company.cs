using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Company : IEntity
    {
        public int id { get; set; }
        public string companyName { get; set; }
    }
}
