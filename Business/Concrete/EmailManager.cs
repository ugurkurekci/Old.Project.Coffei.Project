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

namespace Business.Concrete
{
    public class EmailManager : IEmailService
    {
        IEmailDal _emailDal;

        public EmailManager(IEmailDal emailDal)
        {
            _emailDal = emailDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IEmailService.Get")]

        public IResult Add(Email email)
        {
            IResult result = BusinessRules.Run(EmailNameBlockIfSame(email.EmailName));
            if (result != null)
            {
                return result;
            }
            _emailDal.Add(email);
            return new SuccessResult("Mail eklendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IEmailService.Get")]

        public IResult Delete(Email email)
        {
            _emailDal.Delete(email);
            return new SuccessResult("Mail silindi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<List<Email>> GetAll()
        {
            return new SuccessDataResult<List<Email>>(_emailDal.GetAll(), "Email Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IEmailService.Get")]

        public IResult Update(Email email)
        {
            IResult result = BusinessRules.Run(EmailNameBlockIfSame(email.EmailName));
            if (result != null)
            {
                return result;
            }
            _emailDal.Update(email);
            return new SuccessResult("Mail güncellendi.");
        }

        private IResult EmailNameBlockIfSame(string email)
        {
            var result = _emailDal.GetAll (p => p.EmailName == email).Any();
            if (result)
            {
                return new ErrorResult("Aynı Mail Daha Önce Eklendi. Başka Bir Mail Ekleyiniz .");
            }
            return new SuccessResult();
        }
    }
}
