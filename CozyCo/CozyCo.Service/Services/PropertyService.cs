using System;
using System.Collections.Generic;
using System.Text;
using CozyCo.Data;
using CozyCo.Domain.Models;

namespace CozyCo.Service.Services
{
    public interface IPropertyService
    {
        Property GetById(int id);
        // ICollection<Property> GetLandLordById(int landlordId);

        ICollection<Property> GetAllProperties();

        //Create
        Property Create(Property newProperty);


        //Update

        Property Update(Property updatedProperty);

        //Delete
        bool Delete(int id);


    }



    public class PropertyService : IPropertyService
    {

        private readonly IPropertyService _propertyRepository;

        public PropertyService(IPropertyService propertyRepository)
        {

            _propertyRepository = propertyRepository;


        }
        public Property Create(Property newProperty)
        {
            return _propertyRepository.Create(newProperty);

        }

        public bool Delete(int id)
        {
            return _propertyRepository.Delete(id);
        }

        public Property GetById(int id)
        {
            return _propertyRepository.GetById(id);
        }

        public Property Update(Property updatedProperty)
        {
            return _propertyRepository.Update(updatedProperty);
        }

        public ICollection<Property> GetAllProperties()
        {

            return _propertyRepository.GetAllProperties();

        }
    }
}
