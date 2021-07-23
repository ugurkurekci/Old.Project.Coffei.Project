using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Product : IEntity
    {
        public int productId { get; set; }
        public int categoryId { get; set; }
        public string productName { get; set; }
        public string productBarkodNo { get; set; }
        public string productImage { get; set; }
        public int productStock { get; set; }
        public float productPrice { get; set; }
        public bool isActive { get; set; }

    }
}
