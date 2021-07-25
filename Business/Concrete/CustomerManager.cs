using Business.Abstract;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            IResult result = BusinessRules.Run(CustomerNameBlockIfSame(customer.customerName));
            if (result != null)
            {
                return result;
            }
            _customerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Customer> GetByNameAndSurname(string name, string surname)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Customer> GetByPhone(int phoneNumber)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        private IResult CustomerNameBlockIfSame(string customerName)
        {
            var resultName = _customerDal.GetAll(p => p.customerName == customerName).Any();
            if (resultName)
            {
                return new ErrorResult("Aynı İsim Müşteri Daha Önce Eklendi. Başka Bir Müşteri Ekleyiniz .");
            }
            return new SuccessResult();
        }
    }
}
