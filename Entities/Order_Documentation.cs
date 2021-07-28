using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    [Serializable]

    public class Order_Documentation : IEntity
    {
        [Key]

        public int id { get; set; }
        public int orderTypeId { get; set; }
        public int orderProductId { get; set; }
        public int orderPortionId { get; set; }
        public int orderAmount { get; set; }

        public DateTime orderDate { get; set; }


        public double orderPrice { get; set; }
        public double materialsAddPrice { get; set; }
        public double materialsAddTotalPrice { get; set; }
        public double discount { get; set; }
        public double totalPrice { get;  }



    }
}
