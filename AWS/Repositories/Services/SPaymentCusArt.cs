using AWS.Models;
using AWS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AWS.Repositories.Services
{
    public class SPaymentCusArt : IPaymentCusArt
    {
        private readonly ARTWORKPLATFORMContext cxt;

        public SPaymentCusArt(ARTWORKPLATFORMContext cxt)
        {
            this.cxt = cxt;
        }

        public async Task<PaymentCusArt> CreateNewPaymentCusArt(string OrderCusId)
        {
            try
            {
                var payment = new PaymentCusArt();
                var order = await this.cxt.OrderCusArts
                              .Where(x => x.OrderCusArtId.Equals(OrderCusId))
                              .FirstOrDefaultAsync();
                if (order != null)
                {
                    payment.PaymentCusArtId = "PCA" + Guid.NewGuid().ToString().Substring(0, 8);
                    payment.OrderCusArtId = order.OrderCusArtId;
                    payment.CreateDate = DateTime.Now;
                    payment.Amount = order.Total;
                    payment.Status = false;

                    await this.cxt.PaymentCusArts.AddAsync(payment);
                    await this.cxt.SaveChangesAsync();
                    return payment;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PaymentCusArt>> GetPaymentList()
        {
            try
            {
                var y = await this.cxt.PaymentCusArts.ToListAsync();
                return y;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
