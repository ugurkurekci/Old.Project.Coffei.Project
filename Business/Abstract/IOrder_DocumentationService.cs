using Core.Utilities.Results;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrder_DocumentationService
    {
        IDataResult<List<Order_Documentation>> getAll();
        IDataResult<List<Order_DocumentationDto>> getAllDetails();
        IResult Add(Order_Documentation order_Documentation);
        IResult Delete(Order_Documentation order_Documentation);
        IResult Update(Order_Documentation order_Documentation);
        IDataResult<Order_Documentation> getByProductName(int productName);
        IDataResult<Order_Documentation> getByDiscount(int discount);
        IDataResult<Order_Documentation> getById(int id);
        IDataResult<Order_Documentation> getByOrderDate(DateTime orderDate);
    }
}
