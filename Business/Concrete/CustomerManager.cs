using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("ICategoryService.Get")]
       // [SecuredOperation("Admin")]


        public IResult Add(Customer customer)
        {
            IResult result = BusinessRules.Run(CustomerPhoneBlockIfSame(customer.phone));
            if (result != null)
            {
                return result;
            }
            _customerDal.Add(customer);
            return new SuccessResult("Müşteri Eklendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("ICategoryService.Get")]
       // [SecuredOperation("Admin")]


        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult("Müşteri Silindi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
      //  [SecuredOperation("Admin")]


        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), "Müşteri Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
      //  [SecuredOperation("Admin")]


        public IDataResult<Customer> GetByNameAndSurname(string name, string surname)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.customerName == name || p.customerSurname == surname), "İsim ve Soyisim Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
       // [SecuredOperation("Admin")]

        public IDataResult<Customer> GetByPhone(int phoneNumber)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.phone == phoneNumber), "Telefon Numarası Listelendi");
        }


        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("ICategoryService.Get")]
      //  [SecuredOperation("Admin")]


        public IResult Update(Customer customer)
        {
            
            _customerDal.Update(customer);
            return new SuccessResult("Müşteri Güncellendi.");
        }

        private IResult CustomerPhoneBlockIfSame(int phone)
        {
            var resultName = _customerDal.GetAll(p => p.phone == phone).Any();
            if (resultName)
            {
                return new ErrorResult("Aynı İsim Müşteri Daha Önce Eklendi. Başka Bir Müşteri Ekleyiniz .");
            }
            return new SuccessResult();
        }
    }
}
