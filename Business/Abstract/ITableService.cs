using Core.Utilities.Results;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITableService
    {
        IDataResult<List<Table>> getAll();
        IDataResult<List<TableDetailsDto>> getAllDetails();
        IResult Add(Table table);
        IResult Delete(Table table);
        IResult Update(Table table);
        IDataResult<Table> getById(int id);
        IDataResult<Table> getByTableNameId(int tableName);
        IDataResult<Table> getByTableLocationId(int tableLocation);
        IDataResult<Table> getByTableCapacity(int tableCapacity);
        IDataResult<Table> getByIsActive(bool IsActive);

    }
}
