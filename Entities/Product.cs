using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Product : IEntity
    {
        [Key]
        public int id { get; set; }
        public int categoryId { get; set; }
        public string productName { get; set; }
        public string productBarkodNo { get; set; }
        public string productImage { get; set; }
        public int productStock { get; set; }
        public double productPrice { get; set; }
        public bool isActive { get; set; }

    }
}
