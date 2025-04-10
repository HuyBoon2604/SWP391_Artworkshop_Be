using AWS.Models;

namespace AWS.Repositories.Interfaces
{
    public interface IOrderDetail
    {
       public Task<List<OrderDetail>> GetAllOrderDetails();
       public Task<OrderDetail> GetOrderDetailByOrderId(string id);

    }
}
