using Core.Utilities.Results;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IDataResult<Product> GetById(int id);
        IDataResult<Product> GetByCategoryId(int category_id);

        IDataResult<Product> GetByProductName(string productName);
        IDataResult<Product> GetByProductStock(int productStock);
        IDataResult<Product> GetByProductPrice(float productPrice);


        IDataResult<List<ProductDetailsDto>> GetProductDetails(Expression<Func<Product, bool>> filter = null);


        IResult AddTransactionalTest(Product product);






    }
}
