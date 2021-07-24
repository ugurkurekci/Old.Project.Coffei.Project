using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPayment_DocumentationService
    {
        IDataResult<List<Payment_Documentation>> GetAll();
        IResult Add(Payment_Documentation payment_Documentation);
        IResult Delete(Payment_Documentation payment_Documentation);
        IResult Update(Payment_Documentation payment_Documentation);
        IDataResult<Payment_Documentation> GetByPaymentDate(DateTime paymentDate);
        IDataResult<Payment_Documentation> GetBypaymentName(string paymentName);
        IDataResult<Payment_Documentation> GetById(int id);
        IDataResult<Payment_Documentation> GetByTotalPrice(float totalPrice);

    }
}
