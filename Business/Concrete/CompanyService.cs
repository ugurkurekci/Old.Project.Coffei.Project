using Business.Abstract;
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
using System.Threading;

namespace Business.Concrete
{
    public class CompanyService : ICompanyService
    {

        ICompanyDal _companyDal;

        public CompanyService(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("ICompanyService.Get")]
        // [SecuredOperation("Admin")]


        public IResult Add(Company company)
        {
            IResult result = BusinessRules.Run(CompanyNameBlockIfSame(company.companyName));
            if (result != null)
            {
                return result;
            }
            _companyDal.Add(company);
            return new SuccessResult("Firma Eklendi.");
        }


        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("ICompanyService.Get")]
        // [SecuredOperation("Admin")]

        public IResult Delete(Company company)
        {
            _companyDal.Delete(company);
            return new SuccessResult("Firma Silindi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Company>> getAll()
        {
            Thread.Sleep(3000);
            return new SuccessDataResult<List<Company>>(_companyDal.GetAll(), "Firmalar Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Company>> getByCompanyName(string companyName)
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetAll(p => p.companyName == companyName), "Aranan Firma Listelendi.");

        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<Company> getById(int id)
        {
            return new SuccessDataResult<Company>(_companyDal.Get(p => p.id == id), "Aranan Firma ID Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("ICompanyService.Get")]
        // [SecuredOperation("Admin")]
        public IResult Update(Company company)
        {
            IResult result = BusinessRules.Run(CompanyNameBlockIfSame(company.companyName));
            if (result != null)
            {
                return result;
            }
            _companyDal.Update(company);
            return new SuccessResult("Firma Güncellendi.");
        }



        // ----- rule ----- //

        private IResult CompanyNameBlockIfSame(string companyName)
        {
            var result = _companyDal.GetAll(p => p.companyName == companyName).Any();
            if (result)
            {
                return new ErrorResult("Firma Daha Önce Eklendi. Başka Bir Firma Ekleyiniz .");
            }
            return new SuccessResult();
        }
    }
}
