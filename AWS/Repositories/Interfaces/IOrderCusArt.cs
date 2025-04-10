using AWS.DTO;
using AWS.Models;

namespace AWS.Repositories.Interfaces
{
    public interface IOrderCusArt
    {
        Task<List<OrderCusArt>> GetAllOrderCusArte();
        Task<OrderCusArt> GetOrderCusArtById(string id);
        Task<OrderCusArt> CreateNewOrderCusArt(NewOrderCusArtDTO order, string ArtwokCustomeID);
        Task<bool> UpdateStatuOrderCusArt(string OrderRequireId);
    }
}
