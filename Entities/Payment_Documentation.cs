using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Payment_Documentation : IEntity
    {
        [Key]
        public int id { get; set; }
        public DateTime paymentDate { get; set; }
        public string paymentType { get; set; }
        public string paymentName { get; set; }
        public float totalPrice { get; set; }


    }
}
