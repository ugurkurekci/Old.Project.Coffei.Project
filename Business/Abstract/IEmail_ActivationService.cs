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

        IDataResult<Email_Activation> GetByCode(string code);
        IResult Send(string mail);

    }
}
