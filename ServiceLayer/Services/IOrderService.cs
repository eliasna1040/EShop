using DataLayer.Entities;
using ServiceLayer.DTOs;
using ServiceLayer.ViewModels;

namespace ServiceLayer.Services
{
    public interface IOrderService
    {
        OrderModel CreateOrder(OrderDTO order);
        OrderModel? DisableOrder(int orderId);
        OrderModel? GetOrder(int orderId);
        Page<OrderModel> GetOrders(int page, int count);
    }
}