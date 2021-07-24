using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CoffeiSoftContext>, IUserDal
    {
        public List<Operation_Claim> GetClaims(User user)
        {
            using (var context = new CoffeiSoftContext())
            {
                var result = from Operation_Claim in context.Operation_Claim
                             join User_Operation_Claim in context.User_Operation_Claim
                                 on Operation_Claim.id equals User_Operation_Claim.operationClaim_id
                             where User_Operation_Claim.user_id == user.id
                             select new Operation_Claim { id = Operation_Claim.id, Name = Operation_Claim.Name };
                return result.ToList();
            }
        }
    }
}
