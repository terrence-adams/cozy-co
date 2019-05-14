using CozyCo.Data.Interfaces;
using CozyCo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyCo.Service.Services
{
    public interface IPropertyTypeService
    {
        PropertyTypeService GetById(int id);
        ICollection<PropertyType> GetAll();
    }


    public class PropertyTypeService : IPropertyTypeService
    {
        IPropertyTypeRepository _propertyTypeRepository;

        public PropertyTypeService(IPropertyTypeRepository propertyTypeRepo)
        {

            _propertyTypeRepository = propertyTypeRepo;
        }
        public ICollection<PropertyType> GetAll()
        {
            return _propertyTypeRepository.GetAll();
        }

        public PropertyTypeService GetById(int id)
        {
            return _propertyTypeRepository.GetById(id);
        }
    }
}
