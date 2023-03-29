using DataLayer;
using DataLayer.Entities;
using ServiceLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly EShopContext _context;

        public ManufacturerService(EShopContext context)
        {
            _context = context;
        }

        public void AddManufacturer(ManufacturerDTO manufacturer)
        {
            _context.Manufacturers.Add(new Manufacturer { Name = manufacturer.Name });
            _context.SaveChanges();
        }

        public List<Manufacturer> GetManufacturers()
        {
            return _context.Manufacturers.ToList();
        }

        public void EditManufacturer(Manufacturer newManufacturer)
        {
            Manufacturer? manufacturer = _context.Manufacturers.AsNoTracking().FirstOrDefault(x => x.ManufacturerId == newManufacturer.ManufacturerId);
            if (manufacturer == null)
                return;

            manufacturer = newManufacturer;
            _context.Entry(manufacturer).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void DisableManufacturer(int manufaturerId)
        {
            Manufacturer? manufacturer = _context.Manufacturers.AsNoTracking().FirstOrDefault(x => x.ManufacturerId == manufaturerId);
            if (manufacturer == null)
                return;

            manufacturer.Disabled = !manufacturer.Disabled;
            _context.SaveChanges();
        }
    }
}
