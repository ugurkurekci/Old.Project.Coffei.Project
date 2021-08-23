using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> getAll();
        IDataResult<Category> getById(int id);
        IDataResult<List<Category>> getByCategoryName(string categoryName);
        IDataResult<List<Category>> getByIsActive(bool operation);
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);

    }
}
