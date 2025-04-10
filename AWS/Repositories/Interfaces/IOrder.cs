using AWS.DTO;
using AWS.DTO.Order;
using AWS.Models;
using AWS.Repositories.Services;

namespace AWS.Repositories.Interfaces
{
    public interface IOrder
    {
        Task<Ordertb> GetOrderById(string id);
        Task<Ordertb> GetOrderByStatusTrue(string id);
        Task<Ordertb> GetOrderByStatusFalse(string id);
        Task<List<Ordertb>> GetOrderStatusFalseByUserId(string id);
        Task<List<Ordertb>> GetAll();
        Task<List<Ordertb>> GetAllByUserId(string id);
        Task<Ordertb> CreateNewOrder(CreateOrderDTO order);
        Task<Ordertb> CreateNewOrderCustome(CreateOrderCustomeDTO order);
        Task<Ordertb> UpdateOrder(string orderId);
        Task<Ordertb> DeleteOrder(string orderId);
        Task<bool> DeleteOrderComplete(string orderId);
    }
}
