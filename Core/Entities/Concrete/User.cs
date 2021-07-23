﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User:IEntity
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public byte[] passwordSalt { get; set; }
        public byte[] passwordHash { get; set; }
        public bool status { get; set; }
        public int phone { get; set; }
    }
}
