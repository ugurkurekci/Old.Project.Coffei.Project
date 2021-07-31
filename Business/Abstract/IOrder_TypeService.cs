using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrder_TypeService
    {
        IDataResult<List<Order_Type>> GetAll();
        IResult Add(Order_Type order_Type);
        IResult Delete(Order_Type order_Type);
        IResult Update(Order_Type order_Type);
    }
}
