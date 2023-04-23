using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;
using ServiceLayer.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturersController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        public IActionResult GetManufacturers(int start = 1, int count = 10)
        {
            return Ok(_manufacturerService.GetManufacturers(start, count));
        }

        [HttpPost]
        public IActionResult AddManufacturer(string manufacturer)
        {
            ManufacturerModel? addedManufacturer = _manufacturerService.AddManufacturer(manufacturer);
            if (addedManufacturer != null)
            {
                return Ok(addedManufacturer);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult DisableManufacturer(int id)
        {
            ManufacturerModel? manufacturer = _manufacturerService.DisableManufacturer(id);
            if (manufacturer != null)
            {
                return Ok(manufacturer);
            }

            return BadRequest();
        }
    }
}
