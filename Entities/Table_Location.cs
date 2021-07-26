using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Table_Location : IEntity
    {
        public int id { get; set; }
        public string TableLocationName { get; set; }
    }
}
