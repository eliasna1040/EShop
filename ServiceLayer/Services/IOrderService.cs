using DataLayer.Entities;
using ServiceLayer.DTOs;

namespace ServiceLayer.Services
{
    public interface IOrderService
    {
        void CreateOrder(OrderDTO order);
        void DisableOrder(int orderId);
        Order? GetOrder(int orderId);
        List<Order> GetOrders();
    }
}