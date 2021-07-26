using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Order_Portion : IEntity
    {
        public int id { get; set; }
        public string orderPortionName { get; set; }
    }
}
