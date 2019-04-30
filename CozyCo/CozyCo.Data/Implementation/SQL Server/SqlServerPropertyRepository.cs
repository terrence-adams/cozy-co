using CozyCo.Data.Interfaces;
using CozyCo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CozyCo.Data;
using CozyCo.Data.Context;
using System.Linq;

namespace CozyCo.Data.Implementation.SQL_Server
{
    public class SqlServerPropertyRepository : IPropertyRepository
    {
        public Property Create(Property newProperty)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            using (var context = new CozyCoDbContext())
            {
                Property propertyDeleted;
                propertyDeleted = context.Properties.Find(id);
                context.Properties.Remove(propertyDeleted);
                propertyDeleted = context.Properties.Find(id);
                if (propertyDeleted == null)
                { deleted = true; }

            }

            return deleted;
        }

        public Property GetById(int id)
        {
            Property propertyFound;
            //access the context to get to the database
            using (var context = new CozyCoDbContext())
            {
                //represents the tables in the context : SQL
                propertyFound = context.Properties.Find(id);
                //context.Properties.Single(p => p.ID == id);
            }

            return propertyFound;

        }

        public Property Update(Property updatedProperty)
        {
            throw new NotImplementedException();
        }
    }
}
