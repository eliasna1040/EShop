using DataLayer;
using DataLayer.Entities;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly EShopContext _context;

        public OrderService(EShopContext context)
        {
            _context = context;
        }

        public void CreateOrder(OrderDTO order)
        {
            _context.Orders.Add(new Order { Customer = order.Customer, Products = order.Products });
            _context.SaveChanges();
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.OrderByDescending(x => x.OrderId).ToList();
        }

        public Order? GetOrder(int orderId)
        {
            return _context.Orders.FirstOrDefault(x => x.OrderId == orderId);
        }

        public void DisableOrder(int orderId)
        {
            Order? order = _context.Orders.FirstOrDefault(x => x.OrderId == orderId);
            if (order == null)
                return;

            order.Disabled = !order.Disabled;
            _context.SaveChanges();
        }
    }
}
