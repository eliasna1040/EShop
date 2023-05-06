using DataLayer;
using DataLayer.Entities;
using ServiceLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.ViewModels;
using ServiceLayer.ExtensionMethods;
using Microsoft.AspNetCore.JsonPatch;

namespace ServiceLayer.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly EShopContext _context;

        public ManufacturerService(EShopContext context)
        {
            _context = context;
        }

        public ManufacturerModel AddManufacturer(string manufacturer)
        {
            Manufacturer addedManufacturer = new Manufacturer { Name = manufacturer };
            _context.Manufacturers.Add(addedManufacturer);
            _context.SaveChanges();
            _context.Entry(addedManufacturer).Reload();
            return new ManufacturerModel(addedManufacturer);
        }

        public List<ManufacturerModel> GetManufacturers()
        {
            return _context.Manufacturers.AsNoTracking().Select(x => new ManufacturerModel(x)).ToList();
        }

        public List<ManufacturerModel> GetManufacturersFromSearch(string? search)
        {
            return string.IsNullOrWhiteSpace(search) ? _context.Manufacturers.AsNoTracking().Select(x => new ManufacturerModel(x)).ToList() : _context.Products.Where(p => p.Name.ToLower().Contains(search.ToLower()) || p.Manufacturer.Name.ToLower().Contains(search.ToLower()))
                                                                                             .Include(x => x.Manufacturer)
                                                                                             .Select(x => new ManufacturerModel(x.Manufacturer))
                                                                                             .AsNoTracking()
                                                                                             .ToList();
        }

        public ManufacturerModel? EditManufacturer(int id, JsonPatchDocument<Manufacturer> newManufacturer)
        {
            Manufacturer? manufacturer = _context.Manufacturers.AsNoTracking().FirstOrDefault(x => x.ManufacturerId == id);
            if (manufacturer == null)
                return null;

            newManufacturer.ApplyTo(manufacturer);

            _context.Update(manufacturer);

            _context.SaveChanges();

            return new ManufacturerModel(manufacturer);
        }

        public ManufacturerModel? DisableManufacturer(int manufaturerId)
        {
            Manufacturer? manufacturer = _context.Manufacturers.AsNoTracking().FirstOrDefault(x => x.ManufacturerId == manufaturerId);
            if (manufacturer == null)
                return null;

            manufacturer.Disabled = !manufacturer.Disabled;
            _context.SaveChanges();

            return new ManufacturerModel(manufacturer);
        }
    }
}
