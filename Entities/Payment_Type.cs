using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Payment_Type : IEntity
    {
        public int id { get; set; }
        public string paymentType { get; set; }
    }
}
