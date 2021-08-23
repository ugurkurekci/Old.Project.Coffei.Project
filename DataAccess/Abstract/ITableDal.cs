using Core.DataAccess;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ITableDal : IEntityRepository<Table>
    {
        List<TableDetailsDto> getTableDetails(Expression<Func<Table, bool>> filter = null);

    }
}
