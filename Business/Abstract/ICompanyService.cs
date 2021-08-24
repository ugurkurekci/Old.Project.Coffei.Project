using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        IDataResult<List<Company>> getAll();
        IDataResult<Company> getById(int id);
        IDataResult<List<Company>> getByCompanyName(string companyName);
        IResult Add(Company company);
        IResult Delete(Company company);
        IResult Update(Company company);
    }
}
