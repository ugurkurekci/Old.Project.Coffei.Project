using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebMvc.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        public string categoryName { get; set; }
        public Boolean isActive { get; set; }
    }
}
