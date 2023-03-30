using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
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
            List<Product> products = new();
            order.ProductIds.ForEach(x => products.Add(_context.Products.First(y => y.ProductId == x)));

            _context.Orders.Add(new Order { CustomerId = order.CustomerId, Products = products });
            _context.SaveChanges();
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.OrderByDescending(x => x.OrderId).AsNoTracking().ToList();
        }

        public Order? GetOrder(int orderId)
        {
            return _context.Orders.Include(x => x.Products).Include(x => x.Customer).AsNoTracking().FirstOrDefault(x => x.OrderId == orderId);
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
