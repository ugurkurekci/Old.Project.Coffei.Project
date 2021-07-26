using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Order_Documentation : IEntity
    {
        [Key]
        public int id { get; set; }       
        public int orderTypeId { get; set; }
        public int orderProductId { get; set; }
        public int orderPortionId { get; set; }
        public int orderAmount { get; set; }

        public DateTime orderDate { get; set; }


        public float orderPrice { get; set; }
        public float materialsAddPrice { get; set; }
        public float materialsAddTotalPrice { get; set; }
        public int discount { get; set; }
        public float totalPrice { get; set; }
    }
}
