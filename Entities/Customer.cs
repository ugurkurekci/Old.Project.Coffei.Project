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
        public int id { get; set; }
        public int phoneId { get; set; }
        public int emailId { get; set; }
        public int companyId { get; set; }


        public string customerName { get; set; }
        public string customerSurname { get; set; }
        public DateTime date_of_registration { get; set; }
        public string customerCardNo { get; set; }
        public bool isActive { get; set; }
    }
}
