using System;
using System.Collections.Generic;
using System.Text;
using CozyCo.Domain.Models;

namespace CozyCo.Data.Interfaces
{
    public interface IPropertyTypeRepository
    {

        PropertyType GetById(int id);
        ICollection<PropertyType> GetAll();

    }
}
