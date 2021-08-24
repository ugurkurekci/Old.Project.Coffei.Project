using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        IUserDal _userDal;
        IEmail_ActivationService _email_ActivationService;

        public UserService(IUserDal userDal, IEmail_ActivationService email_ActivationService)
        {
            _userDal = userDal;
            _email_ActivationService = email_ActivationService;
        }

        public void Add(User user)
        {
            IResult result = BusinessRules.Run(CodeIfSame(user.email));           
            _userDal.Add(user);
        }



        public User getByMail(string email)
        {
            return _userDal.Get(p => p.email == email);
        }



        public List<Operation_Claim> getClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        private IResult CodeIfSame(string mail)
        {
            var result = _email_ActivationService.Send(mail);
            if (result!=null)
            {
                return new SuccessResult("Başarılı");
            }
            return new ErrorResult("Başarısız");
        }
    }

}

