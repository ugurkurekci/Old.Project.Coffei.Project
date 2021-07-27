using Core.DataAccess;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IPaymentDal : IEntityRepository<Payment>
    {
        List<PaymentDetailsDto> GetPaymentDetails(Expression<Func<Payment, bool>> filter = null);


    }
}
