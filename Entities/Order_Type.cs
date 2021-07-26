using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Order_Type : IEntity
    {
        public int id { get; set; }
        public string orderTypeName { get; set; }
    }
}
