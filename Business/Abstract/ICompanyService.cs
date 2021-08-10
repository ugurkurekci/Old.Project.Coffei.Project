using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        IDataResult<List<Company>> GetAll();
        IDataResult<Company> GetById(int id);
        IDataResult<List<Company>> GetByCompanyName(string companyName);
        IResult Add(Company company);
        IResult Delete(Company company);
        IResult Update(Company company);
    }
}
