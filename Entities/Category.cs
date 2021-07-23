using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Category : IEntity
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public bool isActive { get; set; }

    }
}
