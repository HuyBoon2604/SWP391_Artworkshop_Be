using AWS.DTO;
using AWS.Models;
using AWS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AWS.Repositories.Services
{
    public class SOrderRequire : IOrderRequire
    {
        private readonly ARTWORKPLATFORMContext cxt;
        public SOrderRequire(ARTWORKPLATFORMContext Cxt)
        {
            cxt = Cxt;
        }
        public async Task<OrderRequire> CreateNewOrderRequire(NewOrderRequireDTO order)
        {
            try
            {
                    var OrderRequire = new OrderRequire
                    {
                        OrderRequireId = "OR" + Guid.NewGuid().ToString().Substring(0, 5),
                        UserId = order.UserID,
                        Status = true,  
                        ArtworkCustomeId = order.ArtworkCustomeID,
                    };

                    await cxt.OrderRequires.AddAsync(OrderRequire); // Corrected to ArtworkCustomes
                    await cxt.SaveChangesAsync();

                    return OrderRequire;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Delette(string OrderRequireId)
        {
            try
            {
                var y = await this.cxt.OrderRequires.Where(x => x.OrderRequireId == OrderRequireId).FirstOrDefaultAsync();
                this.cxt.Remove(y);
                await this.cxt.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<OrderRequire>> GetAllOrderRequire()
        {

            try
            {
                var y = await this.cxt.OrderRequires.ToListAsync();
                return y;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<OrderRequire>> GetOrderRequireByArtCustomeId(string id)
        {
            try
            {
                var y = await this.cxt.OrderRequires.Where(x => x.ArtworkCustomeId == id).ToListAsync();
                return y;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
            public async Task<OrderRequire> GetOrderRequireById(string id){
            try
            {
                var y = await this.cxt.OrderRequires.Where(x => x.OrderRequireId == id).FirstOrDefaultAsync();
                return y;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateStatusOrderRequire(string OrderRequireId)
        {
            try
            {
                var y = await this.cxt.OrderRequires.Where(x => x.OrderRequireId == OrderRequireId).FirstOrDefaultAsync();
                y.Status = true;
                this.cxt.Update(y);
                await this.cxt.SaveChangesAsync();  
                return true ;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
