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
    public class EfProductDal : EfEntityRepositoryBase<Product, CoffeiSoftContext>, IProductDal
    {
        public List<ProductDetailsDto> getProductDetails(Expression<Func<Product, bool>> filter = null)
        {
            using (CoffeiSoftContext contexts = new CoffeiSoftContext())
            {
                var result = from c in filter == null ? contexts.Product : contexts.Product.Where(filter)
                             join b in contexts.Category on c.categoryId equals b.id
                             select new ProductDetailsDto
                             {
                                 id = c.id,
                                 productName = c.productName,
                                 categoryName = b.categoryName,
                                 productImage = c.productImage,
                                 productStock=c.productStock,
                                 isActive=c.isActive,
                                 productBarkodNo=c.productBarkodNo,
                                 productPrice=c.productPrice

                             };
                return result.ToList();
            }
        }
    }
}
