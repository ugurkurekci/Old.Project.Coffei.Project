using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Payment : IEntity
    {
        public int id { get; set; }

        public string paymentName { get; set; }
        public string paymentType { get; set; }
        public string paymentComment { get; set; }


    }
}
