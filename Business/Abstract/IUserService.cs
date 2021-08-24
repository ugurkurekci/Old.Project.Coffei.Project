
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<Operation_Claim> getClaims(User user);
        void Add(User user);
        User getByMail(string email);

    }
}
