using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class Order_DocumentationDto:IDto
    {
        public int id  { get; set; }
        public string orderTypeName { get; set; }
        public string orderProductName { get; set; }
        public string orderPortionName { get; set; }
        public int orderAmount { get; set; }
        public DateTime orderDate { get; set; }
        public double orderPrice { get; set; }
        public double materialsAddPrice { get; set; }
        public double materialsAddTotalPrice { get; set; }
        public int discount { get; set; }
        public double totalPrice { get; set; }
    }
}
