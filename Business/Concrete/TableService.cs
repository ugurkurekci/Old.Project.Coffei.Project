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
using System.Text;

namespace Business.Concrete
{
    public class TableService : ITableService
    {
        ITableDal _tableDal;

        public TableService(ITableDal tableDal)
        {
            _tableDal = tableDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("ITableService.Get")]


        public IResult Add(Table table)
        {
            _tableDal.Add(table);
            return new SuccessResult("Masa eklendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("ITableService.Get")]

        public IResult Delete(Table table)
        {
            _tableDal.Delete(table);
            return new SuccessResult("Masa silindi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<List<Table>> getAll()
        {
            return new SuccessDataResult<List<Table>>(_tableDal.GetAll(), "Masalar Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<List<TableDetailsDto>> getAllDetails()
        {
            return new SuccessDataResult<List<TableDetailsDto>>(_tableDal.getTableDetails(), "Masalar Listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public IDataResult<Table> getById(int id)
        {
            throw new NotImplementedException();
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public IDataResult<Table> getByIsActive(bool IsActive)
        {
            return new SuccessDataResult<Table>(_tableDal.Get(p => p.isActive == IsActive), "aktifler listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<Table> getByTableCapacity(int tableCapacity)
        {
            return new SuccessDataResult<Table>(_tableDal.Get(p => p.tableCapacity == tableCapacity), "Masa kapasiteleri listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<Table> getByTableLocationId(int tableLocation)
        {
            return new SuccessDataResult<Table>(_tableDal.Get(p => p.tableLocationId == tableLocation), "listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]

        public IDataResult<Table> getByTableNameId(int tableName)
        {
            return new SuccessDataResult<Table>(_tableDal.Get(p => p.tableNameId == tableName), "listelendi.");
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("ITableService.Get")]
        
        public IResult Update(Table table)
        {
            _tableDal.Update(table);
            return new SuccessResult("Masa güncellendi.");
        }
    }
}
