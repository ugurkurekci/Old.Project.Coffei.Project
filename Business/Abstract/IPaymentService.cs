using Core.Utilities.Results;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IDataResult<List<Payment>> getAll();
        IDataResult<List<PaymentDetailsDto>> getAllDetails();
        IResult Add(Payment payment);
        IResult Delete(Payment payment);
        IResult Update(Payment payment);
        IDataResult<Payment> getByPaymentName(int paymentName);
        IDataResult<Payment> getById(int id);
    }
}
