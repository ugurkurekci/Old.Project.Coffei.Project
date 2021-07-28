using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrder_DocumentationDal : EfEntityRepositoryBase<Order_Documentation, CoffeiSoftContext>, IOrder_DocumentationDal
    {
       

        public List<Order_DocumentationDto> GetOrderDocumentationDetails(Expression<Func<Order_Documentation, bool>> filter = null)
        {
            using (CoffeiSoftContext contexts = new CoffeiSoftContext())
            {
                var result = from o in filter == null ? contexts.Order_Documentation : contexts.Order_Documentation.Where(filter)
                             join op in contexts.Order_Portion on o.orderPortionId equals op.id
                             join ot in contexts.Order_Type on o.orderTypeId equals ot.id
                             join p in contexts.Product on o.orderProductId equals p.id
                             select new Order_DocumentationDto
                             {
                                 id = o.id,
                                 discount = o.discount,
                                 materialsAddPrice = o.discount,
                                 materialsAddTotalPrice = o.discount,
                                 orderAmount = o.orderAmount,
                                 orderDate = o.orderDate,
                                 orderPortionName = op.orderPortionName,
                                 orderPrice = o.orderPrice,
                                 orderProductName = p.productName,
                                 orderTypeName = ot.orderTypeName,
                                 totalPrice = o.totalPrice,
                                 
                             };
                return result.ToList();
            }

        }
    }
}
