﻿using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("ICategoryService.Get")]

        public IResult Add(Category category)
        {
            IResult result = BusinessRules.Run(CategoryNameBlockIfSame(category.categoryName));
            if (result != null)
            {
                return result;
            }
            _categoryDal.Add(category);
            return new SuccessResult("Kategori Eklendi.");
        }

        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("ICategoryService.Get")]

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult("Kategori Silindi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<List<Category>> GetAll()
        {
            Thread.Sleep(3000);
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(),"Kategori Listelendi.");
        }


        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("ICategoryService.Get")]

        public IResult Update(Category category)
        {
            IResult result = BusinessRules.Run(CategoryNameBlockIfSame(category.categoryName));
            if (result != null)
            {
                return result;
            }
            _categoryDal.Update(category);
            return new SuccessResult("Kategori Güncellendi.");
        }




        private IResult CategoryNameBlockIfSame(string categoryName)
        {
            var result = _categoryDal.GetAll(p => p.categoryName == categoryName).Any();
            if (result)
            {
                return new ErrorResult("Aynı Kategori Daha Önce Eklendi. Başka Bir Kategori Ekleyiniz .");
            }
            return new SuccessResult();
        }
    }
}
