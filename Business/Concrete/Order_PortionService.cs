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
    public class Order_PortionService : IOrder_PortionService
    {
        IOrder_PortionDal _order_PortionDal;

        public Order_PortionService(IOrder_PortionDal order_PortionDal)
        {
            _order_PortionDal = order_PortionDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IOrder_PortionService.Get")]
        public IResult Add(Order_Portion order_Portion)
        {
            IResult result = BusinessRules.Run(orderPortionBlockIfSame(order_Portion.orderPortionName));
            if (result != null)
            {
                return result;
            }
            _order_PortionDal.Add(order_Portion);
            return new SuccessResult(" Porsiyon eklendi.");
        }
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IOrder_PortionService.Get")]
        public IResult Delete(Order_Portion order_Portion)
        {
            _order_PortionDal.Delete(order_Portion);
            return new SuccessResult(" Porsiyon silindi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Order_Portion>> getAll()
        {
            return new SuccessDataResult<List<Order_Portion>>(_order_PortionDal.GetAll(), "Porsiyonlar Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public IDataResult<Order_Portion> getById(int id)
        {
            return new SuccessDataResult<Order_Portion>(_order_PortionDal.Get(p => p.id == id), "Porsiyon ID Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IOrder_PortionService.Get")]
        public IResult Update(Order_Portion order_Portion)
        {
            _order_PortionDal.Update(order_Portion);
            return new SuccessResult(" Porsiyon güncellendi.");
        }

        private IResult orderPortionBlockIfSame(string name)
        {
            var resultName = _order_PortionDal.GetAll(p => p.orderPortionName == name).Any();
            if (resultName)
            {
                return new ErrorResult("Porsiyon ismi mevcut. Başka isim deneyin.");
            }
            return new SuccessResult();
        }
    }
}
