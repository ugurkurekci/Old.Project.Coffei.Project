using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Payment : IEntity
    {
        [Key]
        public int id { get; set; }
        public int paymentNameId { get; set; }
        public int paymentTypeId { get; set; }
        public string paymentComment { get; set; }
        public DateTime paymentDate { get; set; }
        public float totalPrice { get; set; }


    }
}
