using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrder_PortionService
    {
        IDataResult<List<Order_Portion>> getAll();
        IDataResult<Order_Portion> getById(int id);

        IResult Add(Order_Portion order_Portion);
        IResult Delete(Order_Portion order_Portion);
        IResult Update(Order_Portion order_Portion);
    }
}
