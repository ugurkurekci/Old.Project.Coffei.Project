using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public byte[] passwordSalt { get; set; }
        public byte[] passwordHash { get; set; }
        public bool status { get; set; }

        [RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$", ErrorMessage = "Geçerli Telefon Adresi Girin.")]
        public int phone { get; set; }

        public User()
        {
            status = false;
        }

    }
}
