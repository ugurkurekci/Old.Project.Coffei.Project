using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class Email_Activation
    {
        public int phone_id { get; set; }
        public string activationCode { get; set; }
        public string email { get; set; }
        public int MyProperty { get; set; }
        public bool isActivated { get; set; }
        public DateTime activation_date { get; set; }
    }
}
