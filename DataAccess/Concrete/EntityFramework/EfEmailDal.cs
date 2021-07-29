using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEmailDal: EfEntityRepositoryBase<Email, CoffeiSoftContext>, IEmailDal
    {
    }
}
