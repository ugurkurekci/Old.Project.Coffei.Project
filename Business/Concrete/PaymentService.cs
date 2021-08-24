using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentService : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentService(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IPaymentService.Get")]

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult("Ödeme tamamlandı.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IPaymentService.Get")]

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult("Ödeme silindi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<List<Payment>> getAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(), "Ödemeler Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<List<PaymentDetailsDto>> getAllDetails()
        {
            return new SuccessDataResult<List<PaymentDetailsDto>>(_paymentDal.GetPaymentDetails(), "Ödemeler Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<Payment> getById(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.id == id), "Aranan ID Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<Payment> getByPaymentName(int paymentName)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.paymentNameId == paymentName), "Aranan Ödeme Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IPaymentService.Get")]
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult("Ödeme Güncellendi.");
        }
    }
}
