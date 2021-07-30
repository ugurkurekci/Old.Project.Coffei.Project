using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmail_ActivationService
    {
        IDataResult<List<Email_Activation>> GetAll();
        IResult Add(Email_Activation email_Activation);
        IResult Send(string mail);

    }
}
