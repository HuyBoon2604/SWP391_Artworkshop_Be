using AWS.DTO;
using AWS.DTO.ArtworkDTO;
using AWS.DTO.Order;
using AWS.Models;
using AWS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace AWS.Repositories.Services
{
    public class SOrder : IOrder
    {
        private readonly ARTWORKPLATFORMContext cxt;

        public SOrder(ARTWORKPLATFORMContext cxt)
        {
            this.cxt = cxt;
        }

        public async Task<Ordertb> CreateNewOrder(CreateOrderDTO order)
        {
            try
            {
                var add = new Ordertb();
                add.OrderId = "O" + Guid.NewGuid().ToString().Substring(0, 6);
                add.ArtworkId = order.ArtwokID;
                add.UserId = order.UserID;
                add.CreateDate = order.CreateDate;
                add.Status = false;
                add.StatusCancel = true;

                var artwork = await cxt.Artworks.FindAsync(order.ArtwokID);
                if (artwork != null)
                {
                    add.Total = artwork.Price; // Gán giá trị Price từ Artwork cho đơn hàng
                }

                await this.cxt.Ordertbs.AddAsync(add);
                await this.cxt.SaveChangesAsync();
                return add;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
     
        }

        public async Task<Ordertb> CreateNewOrderCustome(CreateOrderCustomeDTO order)
        {
            try
            {
                var add = new Ordertb();
                add.OrderId = "OC" + Guid.NewGuid().ToString().Substring(0, 6);
                //add.ArtworkCustomeId = order.ArtwokCustomeID;
                add.UserId = order.UserID;
                add.CreateDate = order.CreateDate;
                //add.StatusCustome = false;
                //add.StatusCancel = true;
                add.Total = order.Money;

                var ArtworkCustome = await cxt.ArtworkCustomes.FindAsync(order.ArtwokCustomeID);
                if (ArtworkCustome != null)
                {
                    add.Total = ArtworkCustome.Price; // Gán giá trị Price từ ArtworkCustome cho đơn hàng
                }

                await this.cxt.Ordertbs.AddAsync(add);
                await this.cxt.SaveChangesAsync();
                return add;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Ordertb> DeleteOrder(string orderId)
        {
            try
            {
                if (orderId != null)
                {
                    var obj = await this.cxt.Ordertbs.Where(x => x.OrderId.Equals(orderId)).FirstOrDefaultAsync();
                    obj.StatusCancel = false;
                    this.cxt.Ordertbs.Update(obj);
                    await this.cxt.SaveChangesAsync();
                    return obj;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> DeleteOrderComplete(string orderId)
        {
            try
            {
                if (orderId != null)
                {
                    var obj = await this.cxt.Ordertbs.Where(x => x.OrderId.Equals(orderId)).FirstOrDefaultAsync();
                    this.cxt.Ordertbs.Remove(obj);
                    await this.cxt.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<Ordertb>> GetAll()
        {
            try
            {
                var list = await this.cxt.Ordertbs.ToListAsync();
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Ordertb>> GetAllByUserId(string id)
        {
            try
            {
                var a = await this.cxt.Ordertbs.Where(x => x.UserId.Equals(id)).ToListAsync();
                return a;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Ordertb> GetOrderById(string id)
        {
            try
            {
                var a = await this.cxt.Ordertbs.Where(x => x.OrderId.Equals(id)).FirstOrDefaultAsync();
                return a;
            }
            catch (Exception ex) 
            {


                throw new Exception(ex.Message);
            }
          
        }

        public async Task<Ordertb> GetOrderByStatusFalse(string id)
        {
            try
            {
                var a = await this.cxt.Ordertbs.Where(x => x.Status == false && x.OrderId.Equals(id)).FirstOrDefaultAsync();
                return a;

                // Lấy danh sách các order của artwork dựa trên artworkId
                //var orders = await cxt.Ordertbs
                //    .Where(x => x.ArtworkId == id && x.Status == false)
                //    .ToListAsync();


                //// Lặp qua từng order và cập nhật số lượng tiền
                //foreach (var order in orders)
                //{
                //    // Lấy số lượng đơn hàng artwork đã được thêm vào cho order này
                //    int addedArtworkCount = cxt.Ordertbs
                //        .Count(x => x.OrderId == order.OrderId && x.Status == false && x.ArtworkId == artworkId);

                //    // Tính toán số lượng tiền mới của order dựa trên số lượng đơn hàng artwork đã được thêm vào
                //    decimal newTotal = (decimal)(order.Total * addedArtworkCount);

                //    // Cập nhật số lượng tiền của order
                //    order.Total = newTotal;
                //}

                //// Lưu thay đổi vào cơ sở dữ liệu
                //await cxt.SaveChangesAsync();
                //return ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Ordertb> GetOrderByStatusTrue(string id)
        {
             try
            {
                var a = await this.cxt.Ordertbs.Where(x => x.Status == false && x.OrderId.Equals(id)).FirstOrDefaultAsync();
                return a;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Ordertb>> GetOrderStatusFalseByUserId(string id)
        {
            try
            {
                var a = await this.cxt.Ordertbs.Where(x => x.Status == false && x.UserId.Equals(id)).ToListAsync();
                return a;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Ordertb> UpdateOrder(string orderId)
        {
            try
            {
                // Find the payment associated with the paymentId
                //var payment = await cxt.Payments.FirstOrDefaultAsync(p => p.PaymentId == paymentID);

                // Find the order associated with the payment
                var order = await cxt.Ordertbs.FirstOrDefaultAsync(o => o.OrderId == orderId);
           
                // Update order status based on payment status
               
                    order.Status = true; // Assuming true means paid
                    order.StatusProccessing = true;
                 
                cxt.Ordertbs.Update(order);
                await cxt.SaveChangesAsync();

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
