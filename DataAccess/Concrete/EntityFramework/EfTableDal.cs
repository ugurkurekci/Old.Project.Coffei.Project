using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTableDal : EfEntityRepositoryBase<Table, CoffeiSoftContext>, ITableDal
    {
        public List<TableDetailsDto> GetTableDetails(Expression<Func<Table, bool>> filter = null)
        {
            using (CoffeiSoftContext contexts = new CoffeiSoftContext())
            {
                var result = from p in filter == null ? contexts.Table : contexts.Table.Where(filter)
                             join tl in contexts.Table_Location on p.tableLocationId equals tl.id
                             join tn in contexts.Table_Name on p.tableNameId equals tn.id
                             select new TableDetailsDto
                             {
                                 id = p.id,
                                 tableName = tn.tableName,
                                 tableLocationName = tl.TableLocationName,
                                 tableCapacity = p.tableCapacity,
                                 isActive = p.isActive
                             };
                return result.ToList();
            }
        }
    }
}