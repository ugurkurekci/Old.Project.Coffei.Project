using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<Operation_Claim> GetClaims(User user);
        void Add(User user);
        void Delete(User user);
        void MailUpdate(string mail, User user);
        User GetByMail(string email);
        User GetByPhone(int phone);
    }
}
