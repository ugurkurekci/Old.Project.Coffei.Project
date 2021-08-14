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
    public class Order_TypeManager : IOrder_TypeService
    {
        IOrder_TypeDal _order_TypeDal;

        public Order_TypeManager(IOrder_TypeDal order_TypeDal)
        {
            _order_TypeDal = order_TypeDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IOrder_TypeService.Get")]
        public IResult Add(Order_Type order_Type)
        {
            IResult result = BusinessRules.Run(orderTypeBlockIfSame(order_Type.orderTypeName));
            if (result != null)
            {
                return result;
            }
            _order_TypeDal.Add(order_Type);
            return new SuccessResult(" Tip eklendi.");
        }
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IOrder_TypeService.Get")]
        public IResult Delete(Order_Type order_Type)
        {
            _order_TypeDal.Delete(order_Type);
            return new SuccessResult(" Tip silindi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Order_Type>> GetAll()
        {
            return new SuccessDataResult<List<Order_Type>>(_order_TypeDal.GetAll(), "Tip Listelendi.");
        }

        public IDataResult<Order_Type> GetByid(int id)
        {
            return new SuccessDataResult<Order_Type>(_order_TypeDal.Get(p => p.id == id), "Tip ID Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IOrder_TypeService.Get")]
        public IResult Update(Order_Type order_Type)
        {
            _order_TypeDal.Update(order_Type);
            return new SuccessResult(" Tip güncellendi.");
        }

        private IResult orderTypeBlockIfSame(string name)
        {
            var resultName = _order_TypeDal.GetAll(p => p.orderTypeName == name).Any();
            if (resultName)
            {
                return new ErrorResult("Porsiyon ismi mevcut. Başka isim deneyin.");
            }
            return new SuccessResult();
        }
    }
}
