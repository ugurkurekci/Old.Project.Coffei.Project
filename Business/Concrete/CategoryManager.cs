using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            IResult result = BusinessRules.Run(CategoryNameBlockIfSame(category.categoryName));
            if (result != null)
            {
                return result;
            }
            _categoryDal.Add(category);
            return new SuccessResult();
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IResult Update(Category category)
        {
            IResult result = BusinessRules.Run(CategoryNameBlockIfSame(category.categoryName));
            if (result != null)
            {
                return result;
            }
            _categoryDal.Update(category);
            return new SuccessResult();
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
