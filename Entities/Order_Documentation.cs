using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Order_Documentation : IEntity
    {
        public int id { get; set; }
        public DateTime orderDate { get; set; }
        public string orderType { get; set; }
        public string orderProduct { get; set; }
        public string orderPortion { get; set; }
        public int orderAmount { get; set; }
        public float orderPrice { get; set; }
        public float materialsAddPrice { get; set; }
        public float materialsAddTotalPrice { get; set; }
        public int discount { get; set; }
        public float totalPrice { get; set; }
    }
}
