using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Customer : IEntity
    {
        [Key]
        public int phone { get; set; }
        public string customerName { get; set; }
        public string customerSurname { get; set; }
        public string customerCompany { get; set; }
        public DateTime date_of_registration { get; set; }
        public string customerCardNo { get; set; }
        public string email { get; set; }
        public bool isActive { get; set; }
    }
}
