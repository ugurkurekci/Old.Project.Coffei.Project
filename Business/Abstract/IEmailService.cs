using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEmailService
    {
        IDataResult<List<Email>> getAll();
        IResult Add(Email email);
        IResult Delete(Email email);
        IResult Update(Email email);
    }
}
