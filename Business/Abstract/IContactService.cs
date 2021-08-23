using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IContactService
    {
        IDataResult<List<Contact>> getAll();
        IResult Add(Contact contact);
        IResult Delete(Contact contact);
        IResult Update(Contact contact);
        IDataResult<List<Contact>> getByEmail(string email);
        IDataResult<Contact> getById(int id);


    }
}
