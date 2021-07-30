using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Email_Activation : IEntity
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public bool IsActive { get; set; }
        public string code { get; set; }
        public string personCode { get; set; }

        public Email_Activation()
        {          
            IsActive = false;
        }
    }
}
