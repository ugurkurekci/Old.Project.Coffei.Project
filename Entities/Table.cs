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
        public string tableName { get; set; }
        public string tableLocation { get; set; }
        public int tableCapacity { get; set; }
        public bool isActive { get; set; }
    }
}
