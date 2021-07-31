using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Order_Portion : IEntity
    {
        [Key]
        public int id { get; set; }
        public string orderPortionName { get; set; }
    }
}
