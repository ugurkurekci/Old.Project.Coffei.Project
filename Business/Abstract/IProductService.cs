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
        IDataResult<List<Product>> getAll();
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IDataResult<Product> getById(int id);
        IDataResult<Product> getByCategoryId(int category_id);

        IDataResult<Product> getByProductName(string productName);
        IDataResult<Product> getByProductStock(int productStock);
        IDataResult<Product> getByProductPrice(double productPrice);


        IDataResult<List<ProductDetailsDto>> getProductDetails(Expression<Func<Product, bool>> filter = null);


        IResult addTransactionalTest(Product product);






    }
}
