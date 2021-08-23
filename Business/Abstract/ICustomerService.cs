using Core.Utilities.Results;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> getAll();
        IDataResult<List<CustomerDetailsDto>> getCustomerDetailsDto();
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
        IDataResult<Customer> getByPhone(int phoneNumber);
        IDataResult<Customer> getByNameAndSurname(string name, string surname);
    }
}
