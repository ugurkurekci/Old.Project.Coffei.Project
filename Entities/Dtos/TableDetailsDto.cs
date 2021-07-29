using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class TableDetailsDto:IDto
    {
        public int id { get; set; }
        public string tableName{ get; set; }
        public string tableLocationName { get; set; }
        public int tableCapacity { get; set; }
        public bool isActive { get; set; }
    }
}
