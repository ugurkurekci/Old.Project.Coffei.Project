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
    public class EfPaymentDal : EfEntityRepositoryBase<Payment, CoffeiSoftContext>, IPaymentDal
    {
        public List<PaymentDetailsDto> GetPaymentDetails(Expression<Func<Payment, bool>> filter = null)
        {
            using (CoffeiSoftContext contexts = new CoffeiSoftContext())
            {
                var result = from p in filter == null ? contexts.Payment : contexts.Payment.Where(filter)
                             join pn in contexts.Payment_Name on p.paymentNameId equals pn.id
                             join pt in contexts.Payment_Type on p.paymentTypeId equals pt.id
                             select new PaymentDetailsDto
                             {
                                 id = p.id,
                                 paymentName = pn.paymentName,
                                 paymentType = pt.paymentType,
                                 paymentComment = p.paymentComment,
                                 paymentDate = p.paymentDate,
                                 totalPrice = p.totalPrice
                             };
                return result.ToList();


            }
        }
    }
}
