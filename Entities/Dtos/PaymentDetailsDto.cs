using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class PaymentDetailsDto : IDto
    {
        public int id { get; set; }
        public string paymentName { get; set; }
        public string paymentType { get; set; }
        public string paymentComment { get; set; }
        public DateTime paymentDate { get; set; }
        public float totalPrice { get; set; }
    }
}
