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
        IDataResult<List<Table>> GetAll();
        IDataResult<List<TableDetailsDto>> GetAllDetails();
        IResult Add(Table table);
        IResult Delete(Table table);
        IResult Update(Table table);
        IDataResult<Table> GetById(int id);
        IDataResult<Table> GetByTableNameId(int tableName);
        IDataResult<Table> GetByTableLocationId(int tableLocation);
        IDataResult<Table> GetByTableCapacity(int tableCapacity);
        IDataResult<Table> GetByIsActive(bool IsActive);

    }
}
