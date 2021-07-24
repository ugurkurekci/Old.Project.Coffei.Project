using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Category : IEntity
    {
        [Key]
        public int id { get; set; }
        public string categoryName { get; set; }
        public Boolean isActive { get; set; }

    }
}
