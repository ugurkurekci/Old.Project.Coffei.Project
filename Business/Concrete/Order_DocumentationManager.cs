using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class Order_DocumentationManager : IOrder_DocumentationService
    {
        IOrder_DocumentationDal _order_DocumentationDal;

        public Order_DocumentationManager(IOrder_DocumentationDal order_DocumentationDal)
        {
            _order_DocumentationDal = order_DocumentationDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IOrder_DocumentationService.Get")]
        // [SecuredOperation("Admin")]

        public IResult Add(Order_Documentation order_Documentation)
        {

            _order_DocumentationDal.Add(order_Documentation);
            return new SuccessResult("Sipariş eklendi");

        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IOrder_DocumentationService.Get")]

        public IResult Delete(Order_Documentation order_Documentation)
        {
            _order_DocumentationDal.Delete(order_Documentation);
            return new SuccessResult("Sipariş silindi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<List<Order_Documentation>> GetAll()
        {

            return new SuccessDataResult<List<Order_Documentation>>(_order_DocumentationDal.GetAll(), "Listelendi.");


        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<List<Order_DocumentationDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<Order_DocumentationDto>>(_order_DocumentationDal.GetOrderDocumentationDetails(), "Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<Order_Documentation> GetByDiscount(int discount)
        {
            return new SuccessDataResult<Order_Documentation>(_order_DocumentationDal.Get(p => p.discount == discount), "Satış İndirimler Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<Order_Documentation> GetById(int id)
        {
            return new SuccessDataResult<Order_Documentation>(_order_DocumentationDal.Get(p => p.id == id), "Satış ID Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<Order_Documentation> GetByOrderDate(DateTime orderDate)
        {
            return new SuccessDataResult<Order_Documentation>(_order_DocumentationDal.Get(p => p.orderDate == orderDate), "Satış Tarih Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public IDataResult<Order_Documentation> GetByProductName(int productName)
        {
            return new SuccessDataResult<Order_Documentation>(_order_DocumentationDal.Get(p => p.orderProductId == productName), "Satış productId Listelendi.");

        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IOrder_DocumentationService.Get")]

        public IResult Update(Order_Documentation order_Documentation)
        {
            _order_DocumentationDal.Add(order_Documentation);
            return new SuccessResult("Sipariş güncellendi.");
        }

    }


}
