using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrder_DocumentationService
    {
        IDataResult<List<Order_Documentation>> GetAll();
        IResult Add(Order_Documentation order_Documentation);
        IResult Delete(Order_Documentation order_Documentation);
        IResult Update(Order_Documentation order_Documentation);
        IDataResult<Order_Documentation> GetByProductName(int productName);
        IDataResult<Order_Documentation> GetByDiscount(int discount);
        IDataResult<Order_Documentation> GetById(int id);
        IDataResult<Order_Documentation> GetByOrderDate(DateTime orderDate);
    }
}
