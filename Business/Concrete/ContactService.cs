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
using System.Text;

namespace Business.Concrete
{
    public class ContactService : IContactService
    {
        IContactDal _contactDal;
        IEmail_ActivationService _email_ActivationService;

        public ContactService(IContactDal contactDal, IEmail_ActivationService email_ActivationService)
        {
            _contactDal = contactDal;
            _email_ActivationService = email_ActivationService;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IContactService.Get")]

        public IResult Add(Contact contact)
        {
            IResult result = BusinessRules.Run(InfoSame(contact.email));

            _contactDal.Add(contact);
            return new SuccessResult();
        }
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IContactService.Get")]
        public IResult Delete(Contact contact)
        {
            _contactDal.Add(contact);
            return new SuccessResult("Mesaj Silindi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<List<Contact>> getAll()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll(), "Mesajlar Listelendi.");

        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<List<Contact>> getByEmail(string email)
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll(p => p.email == email), "Mesaj ID Listelendi.");
        }


        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<Contact> getById(int id)
        {
            return new SuccessDataResult<Contact>(_contactDal.Get(p => p.id == id), "Mesaj ID Listelendi.");
        }
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IContactService.Get")]
        public IResult Update(Contact contact)
        {
            _contactDal.Add(contact);
            return new SuccessResult("Mesaj Güncellendi..");
        }

        private IResult InfoSame(string contact)
        {
            var result = _email_ActivationService.Info(contact);
            if (result != null)
            {
                return new SuccessResult("Başarılı");
            }
            return new ErrorResult("Başarısız");
        }
    }
}
