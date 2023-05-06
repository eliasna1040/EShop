using DataLayer.Entities;
using Microsoft.AspNetCore.JsonPatch;
using ServiceLayer.DTOs;
using ServiceLayer.ViewModels;

namespace ServiceLayer.Services
{
    public interface IManufacturerService
    {
        ManufacturerModel AddManufacturer(string manufacturer);
        ManufacturerModel? DisableManufacturer(int manufaturerId);
        ManufacturerModel? EditManufacturer(int id, JsonPatchDocument<Manufacturer> newManufacturer);
        List<ManufacturerModel> GetManufacturers();
        List<ManufacturerModel> GetManufacturersFromSearch(string? search);
    }
}