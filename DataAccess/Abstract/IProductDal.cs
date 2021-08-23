using Core.DataAccess;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetailsDto> getProductDetails(Expression<Func<Product, bool>> filter = null);
    }
}
