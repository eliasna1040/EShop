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
        public IActionResult GetManufacturers()
        {
            return Ok(_manufacturerService.GetManufacturers());
        }

        [HttpPost]
        public IActionResult AddManufacturer(string manufacturer)
        {
            try
            {
                return Ok(_manufacturerService.AddManufacturer(manufacturer));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult DisableManufacturer(int id)
        {
            try
            {
                return Ok(_manufacturerService.DisableManufacturer(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
