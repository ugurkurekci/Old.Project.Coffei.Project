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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CoffeiSoftContext>, ICustomerDal
    {
        public List<CustomerDetailsDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (CoffeiSoftContext contexts = new CoffeiSoftContext())
            {
                var result = from c in filter == null ? contexts.Customer : contexts.Customer.Where(filter)
                             join e in contexts.Email on c.emailId equals e.id
                             join p in contexts.Phone on c.phoneId equals p.id
                             join co in contexts.Company on c.companyId equals co.id
                             select new CustomerDetailsDto
                             {
                                 id = c.id,
                                 companyName = co.companyName,
                                 phoneName=p.phoneNumber,
                                 customerName = c.customerName,
                                 customerSurname = c.customerSurname,
                                 emailName = e.EmailName,
                                 customerCardNo = c.customerCardNo,
                                 date_of_registration = c.date_of_registration,
                                 isActive = c.isActive
                             };
                return result.ToList();
            }
        }
    }
}
