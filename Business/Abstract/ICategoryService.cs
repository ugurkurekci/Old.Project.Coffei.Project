using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetByid(int id);
        IDataResult<Category> GetByCategoryName(string categoryName);
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}
