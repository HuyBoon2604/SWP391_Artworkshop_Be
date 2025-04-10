using AWS.Models;

namespace AWS.Repositories.Interfaces
{
    public interface IPaymentCusArt
    {
        Task<List<PaymentCusArt>> GetPaymentList();
        Task<PaymentCusArt> CreateNewPaymentCusArt(string OrderCusId);

    }
}
