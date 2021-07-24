using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(p => p.email == email);
        }

        public User GetByPhone(int phone)
        {
            return _userDal.Get(p => p.phone == phone);
        }

        public List<Operation_Claim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void MailUpdate(string mail, User user)
        {
            var emailcheck = _userDal.GetAll(p => p.email == mail);
            if (emailcheck != null)
            {
                _userDal.Update(user);
            }
        }

        
    }
}
