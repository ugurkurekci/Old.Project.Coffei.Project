using Business.Abstract;
using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class Order_DocumentationManager : IOrder_DocumentationService
    {
        public IResult Add(Order_Documentation order_Documentation)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Order_Documentation order_Documentation)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Order_Documentation>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Order_Documentation> GetByDiscount(int discount)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Order_Documentation> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Order_Documentation> GetByOrderDate(DateTime orderDate)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Order_Documentation> GetByProductName(int productName)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Order_Documentation order_Documentation)
        {
            throw new NotImplementedException();
        }
    }
}
