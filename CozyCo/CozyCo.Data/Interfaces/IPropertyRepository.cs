﻿using CozyCo.Domain.Models;

namespace CozyCo.Data.Interfaces
{
    public interface IPropertyRepository
    {
        //Read
        Property GetById(int id);

        // ICollection<Property> GetLandLordById(int landlordId);

        //Create
        Property Create(Property newProperty);

        //Update

        Property Update(Property updatedProperty);

        //Delete
        bool Delete(int id);
    }
}