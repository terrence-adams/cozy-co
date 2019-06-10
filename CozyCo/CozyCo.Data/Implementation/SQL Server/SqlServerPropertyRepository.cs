﻿using CozyCo.Data.Context;
using CozyCo.Data.Interfaces;
using CozyCo.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CozyCo.Data.Implementation.SQL_Server
{
    public class SqlServerPropertyRepository : IPropertyRepository
    {
        public Property Create(Property newProperty)
        {
            using (var context = new CozyCoDbContext())
            {
                context.Properties.Add(newProperty);
                context.SaveChanges();
                return newProperty;
            }

            //ID property will be populated - this is a reference to the original
        }

        public ICollection<Property> GetAllPropertiesByUserId(string userId)
        {
            using (var context = new CozyCoDbContext())
            {
                return context.Properties
                    .Where(p => p.AppUserId == userId)
                    .ToList();
            }
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            using (var context = new CozyCoDbContext())
            {
                Property propertyDeleted;
                propertyDeleted = GetById(id);
                context.Properties.Remove(propertyDeleted);
                context.SaveChanges();
                propertyDeleted = context.Properties.Find(id);
                if (GetById(id) == null)
                { deleted = true; }

                return deleted;
            }
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
                return propertyFound;
            }
        }

        public Property Update(Property updatedProperty)
        {
            using (var context = new CozyCoDbContext())
            {
                var propertyUpdated = GetById(updatedProperty.ID);
                context.Entry(propertyUpdated).CurrentValues
                    .SetValues(updatedProperty);
                context.Properties.Update(updatedProperty);
                context.SaveChanges();
                return updatedProperty;
            }
        }
    }
}