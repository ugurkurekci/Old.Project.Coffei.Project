using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITableService
    {
        IDataResult<List<Table>> GetAll();
        IResult Add(Table table);
        IResult Delete(Table table);
        IResult Update(Table table);
        IDataResult<Table> GetById(int id);
        IDataResult<Table> GetByTableName(string tableName);
        IDataResult<Table> GetByTableLocation(string tableLocation);
        IDataResult<Table> GetByTableCapacity(int tableCapacity);
        IDataResult<Table> GetByIsActive(bool IsActive);

    }
}
