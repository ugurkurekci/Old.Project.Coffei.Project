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
        IDataResult<List<Email_Activation>> getAll();

        IDataResult<Email_Activation> getByCode(string code);
        IResult Send(string mail);

        IResult Info(string contact);

    }
}
