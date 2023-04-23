using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Services;
using ServiceLayer.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetOrders(int start = 1, int count = 10)
        {
            return Ok(_orderService.GetOrders(start, count));
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            OrderModel? order = _orderService.GetOrder(id);
            if (order != null)
            {
                return Ok(order);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderDTO order)
        {
            OrderModel? addedOrder = _orderService.CreateOrder(order);
            if (addedOrder != null)
            {
                return Ok(addedOrder);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult DisableOrder(int id)
        {
            OrderModel? order = _orderService.DisableOrder(id);
            if (order != null)
            {
                return Ok(order);
            }

            return BadRequest();
        }
    }
}
