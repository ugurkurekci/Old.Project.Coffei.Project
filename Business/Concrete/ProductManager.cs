using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IProductService.Get")]

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult("Ürün eklendi.");
        }

        public IResult addTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IProductService.Get")]

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult("Ürün silindi.");
        }


        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<List<Product>> getAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), "Ürünler Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<Product> getByCategoryId(int category_id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.categoryId == category_id), "Aranan Kategori Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<Product> getById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.id == id), "Aranan ID Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<Product> getByProductName(string productName)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.productName == productName), "Aranan Ürün adı listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<Product> getByProductPrice(double productPrice)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.productPrice == productPrice), "Aranan Ürün fiyatı Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public IDataResult<Product> getByProductStock(int productStock)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.productStock == productStock), "Aranan ürün stoğu Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<List<ProductDetailsDto>> getProductDetails(Expression<Func<Product, bool>> filter = null)
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.getProductDetails(), "Ürünler Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IProductService.Get")]

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult("Ürün güncellendi.");
        }
    }
}
