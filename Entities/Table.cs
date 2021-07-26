using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
   public class Table :IEntity
    {
        [Key]
        public int id { get; set; }
        public int tableNameId { get; set; }
        public int tableLocationId { get; set; }
        public int tableCapacity { get; set; }
        public bool isActive { get; set; }
    }
}
