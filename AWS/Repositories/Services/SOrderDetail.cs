using AWS.Models;
using AWS.Repositories.Interfaces;

namespace AWS.Repositories.Services
{

    public class SOrderDetail : IOrderDetail
    {
        public Task<List<OrderDetail>> GetAllOrderDetails()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail> GetOrderDetailByOrderId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
