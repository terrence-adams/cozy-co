using CozyCo.Domain.Models;
using System.Collections.Generic;

namespace CozyCo.Data.Interfaces
{
    public interface IPropertyTypeRepository
    {
        PropertyType GetById(int id);

        ICollection<PropertyType> GetAll();
    }
}