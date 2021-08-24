using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrder_TypeService
    {
        IDataResult<List<Order_Type>> getAll();
        IResult Add(Order_Type order_Type);
        IResult Delete(Order_Type order_Type);
        IResult Update(Order_Type order_Type);
        IDataResult<Order_Type> getById(int id);

    }
}
