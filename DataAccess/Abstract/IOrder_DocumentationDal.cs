using Core.DataAccess;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
  public  interface IOrder_DocumentationDal:IEntityRepository<Order_Documentation>
    {
        List<Order_DocumentationDto> GetOrderDocumentationDetails(Expression<Func<Order_Documentation, bool>> filter = null);


    }
}
