using Business.Abstract;
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

        public IResult Add(Order_Documentation order_Documentation)
        {

            _order_DocumentationDal.Add(order_Documentation);
            return new SuccessResult("Sipariş eklendi");
        }



        public IResult Delete(Order_Documentation order_Documentation)
        {
            _order_DocumentationDal.Delete(order_Documentation);
            return new SuccessResult("Sipariş silindi.");
        }

        public IDataResult<List<Order_Documentation>> GetAll()
        {

            return new SuccessDataResult<List<Order_Documentation>>(_order_DocumentationDal.GetAll(), "Listelendi.");


        }

        public IDataResult<List<Order_DocumentationDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<Order_DocumentationDto>>(_order_DocumentationDal.GetOrderDocumentationDetails(), "Listelendi.");
        }

        public IDataResult<Order_Documentation> GetByDiscount(int discount)
        {
            return new SuccessDataResult<Order_Documentation>(_order_DocumentationDal.Get(p => p.discount == discount), "Satış İndirimler Listelendi.");
        }

        public IDataResult<Order_Documentation> GetById(int id)
        {
            return new SuccessDataResult<Order_Documentation>(_order_DocumentationDal.Get(p => p.id == id), "Satış ID Listelendi.");
        }

        public IDataResult<Order_Documentation> GetByOrderDate(DateTime orderDate)
        {
            return new SuccessDataResult<Order_Documentation>(_order_DocumentationDal.Get(p => p.orderDate == orderDate), "Satış Tarih Listelendi.");
        }

        public IDataResult<Order_Documentation> GetByProductName(int productName)
        {
            return new SuccessDataResult<Order_Documentation>(_order_DocumentationDal.Get(p => p.orderProductId == productName), "Satış productId Listelendi.");

        }

        public IResult Update(Order_Documentation order_Documentation)
        {
            _order_DocumentationDal.Add(order_Documentation);
            return new SuccessResult("Sipariş güncellendi.");
        }

       
        private IResult discountEntegre(double discount)
        {
            var result = _order_DocumentationDal.GetAll(p => p.discount == discount).Any();
            if (result)
            {
                return new ErrorResult("Ayarlanacak.");
            }
            return new SuccessResult();
        }

    }

}
