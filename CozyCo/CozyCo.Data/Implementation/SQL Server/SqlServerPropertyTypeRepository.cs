using CozyCo.Data.Context;
using CozyCo.Data.Interfaces;
using CozyCo.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CozyCo.Data.Implementation.SQL_Server
{
    public class SqlServerPropertyTypeRepository : IPropertyTypeRepository
    {
        public ICollection<PropertyType> GetAll()
        {
            using (var context = new CozyCoDbContext())
            {
                return context.PropertyTypes.ToList();
            }
        }

        public PropertyType GetById(int id)
        {
            using (var context = new CozyCoDbContext())
            {
                return context.PropertyTypes.SingleOrDefault(pt => pt.Id == id);
            }
        }
    }
}