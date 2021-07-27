using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CustomerDetailsDto : IDto
    {
        public int id { get; set; }
        public  string phoneName { get; set; }
        public string emailName { get; set; }
        public string companyName  { get; set; }



        public string customerName { get; set; }
        public string customerSurname { get; set; }
        public DateTime date_of_registration { get; set; }
        public string customerCardNo { get; set; }
        public bool isActive { get; set; }
    }
}
