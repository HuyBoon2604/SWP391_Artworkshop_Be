using AWS.DTO;
using AWS.Models;
using AWS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AWS.Repositories.Services
{
    public class SOrderCusArt : IOrderCusArt
    {
        private readonly ARTWORKPLATFORMContext cxt;

        public SOrderCusArt(ARTWORKPLATFORMContext cxt)
        {
            this.cxt = cxt;
        }

        public async Task<OrderCusArt> CreateNewOrderCusArt(NewOrderCusArtDTO order, string ArtwokCustomeID)
        {
            try
            {
                var OrderCusArt = new OrderCusArt
                {
                    OrderCusArtId = "OCA" + Guid.NewGuid().ToString().Substring(0, 5),
                    OrderRequireId = order.OrderRequiredID,
                    CreateDate = DateTime.Now,  
                    Status = false,
                };


                var ArtworkCustome = await cxt.ArtworkCustomes.Where(x=>x.ArtworkCustomeId == ArtwokCustomeID).FirstOrDefaultAsync();
                if (ArtworkCustome != null)
                {
                    OrderCusArt.Total = ArtworkCustome.Price; // Gán giá trị Price từ ArtworkCustome cho đơn hàng
                }

                await this.cxt.OrderCusArts.AddAsync(OrderCusArt);
                await this.cxt.SaveChangesAsync();
                return OrderCusArt;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<OrderCusArt>> GetAllOrderCusArte()
        {
            try
            {
                var AllOrderCusArte = await cxt.OrderCusArts.ToListAsync();
                return AllOrderCusArte;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<OrderCusArt> GetOrderCusArtById(string id)
        {
            try
            {
                var AllOrderCusArte = await cxt.OrderCusArts.Where(x => x.OrderCusArtId == id).FirstOrDefaultAsync() ;
                return AllOrderCusArte;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateStatuOrderCusArt(string OrderRequireId)
        {
            try
            {
                var AllOrderCusArte = await cxt.OrderCusArts.Where(x => x.OrderCusArtId == OrderRequireId).FirstOrDefaultAsync();
                AllOrderCusArte.Status = true;
                this.cxt.OrderCusArts.Update(AllOrderCusArte);
                await this.cxt.SaveChangesAsync();

                return true;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
