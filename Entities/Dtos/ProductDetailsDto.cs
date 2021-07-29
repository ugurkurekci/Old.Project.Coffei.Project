using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class ProductDetailsDto : IDto
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public string productName { get; set; }
        public string productImage { get; set; }
        public string productBarkodNo { get; set; }
        public int productStock { get; set; }
        public double productPrice { get; set; }
        public bool isActive { get; set; }

    }
}
