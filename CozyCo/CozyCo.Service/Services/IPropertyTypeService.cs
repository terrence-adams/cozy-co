using System.Collections.Generic;

namespace CozyCo.Service.Services
{
    public interface IPropertyTypeService
    {
        PropertyType GetById(int id);

        ICollection<PropertyType> GetAll();
    }

    public class PropertyTypeService : IPropertyTypeService
    {
        private readonly IPropertyTypeRepository _propertyTypeRepository;

        public PropertyTypeService(IPropertyTypeRepository propertyTypeRepo)
        {
            _propertyTypeRepository = propertyTypeRepo;
        }

        public ICollection<PropertyType> GetAll()
        {
            return _propertyTypeRepository.GetAll();
        }

        public PropertyType GetById(int id)
        {
            return _propertyTypeRepository.GetById(id);
        }
    }
}