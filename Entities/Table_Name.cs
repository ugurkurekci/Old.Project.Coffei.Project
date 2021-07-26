using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Table_Name : IEntity
    {
        public int id { get; set; }
        public string tableName { get; set; }
    }
}
