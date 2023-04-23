using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs;
using ServiceLayer.ExtensionMethods;
using ServiceLayer.ViewModels;
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

        public OrderModel CreateOrder(OrderDTO order)
        {
            List<Product> products = new();

            Order addedOrder = new Order
            {
                CustomerId = order.CustomerId,
                OrdersProducts = order.OrdersProducts.Select(x => new OrderProduct
                {
                    ProductId = x.ProductId,
                    Amount = x.Amount
                }).ToList()
            };
            _context.Orders.Add(addedOrder);
            _context.SaveChanges();
            _context.Entry(addedOrder).Reload();
            _context.Entry(addedOrder).Reference(x => x.Customer).Load();
            _context.Entry(addedOrder).Collection(x => x.OrdersProducts).Query().Include(x => x.Product).Load();

            return new OrderModel(addedOrder);
        }

        public Page<OrderModel> GetOrders(int page, int count)
        {
            IQueryable<Order> query = _context.Orders.Include(x => x.OrdersProducts)
                                                     .ThenInclude(x => x.Product)
                                                     .Include(x => x.Customer)
                                                     .OrderByDescending(x => x.OrderId)
                                                     .AsNoTracking();

            return new Page<OrderModel> { CurrentPage = page, Items = query.Page(page, count).Select(x => new OrderModel(x)).ToList(), Total = query.Count(), PageSize = count };
        }

        public OrderModel? GetOrder(int orderId)
        {
            return _context.Orders.Where(x => x.OrderId == orderId)
                                  .Include(x => x.OrdersProducts)
                                  .ThenInclude(x => x.Product)
                                  .Include(x => x.Customer)
                                  .Select(x => new OrderModel(x))
                                  .AsNoTracking()
                                  .FirstOrDefault();
        }

        public OrderModel? DisableOrder(int orderId)
        {
            Order? order = _context.Orders.Include(x => x.OrdersProducts)
                                          .ThenInclude(x => x.Product)
                                          .Include(x => x.Customer)
                                          .FirstOrDefault(x => x.OrderId == orderId);
            if (order == null)
                return null;

            order.Disabled = !order.Disabled;
            _context.SaveChanges();

            return new OrderModel(order);
        }
    }
}
