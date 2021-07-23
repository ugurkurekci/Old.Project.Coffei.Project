using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User_Operation_Claim :IEntity
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int operationClaim_id { get; set; }
    }
}
