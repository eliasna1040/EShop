using DataLayer.Entities;
using ServiceLayer.DTOs;

namespace ServiceLayer.Services
{
    public interface IManufacturerService
    {
        void AddManufacturer(ManufacturerDTO manufacturer);
        void DisableManufacturer(int manufaturerId);
        void EditManufacturer(Manufacturer newManufacturer);
        List<Manufacturer> GetManufacturers();
    }
}