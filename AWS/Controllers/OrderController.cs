using AWS.DTO;
using AWS.DTO.Order;
using AWS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder order;

        public OrderController(IOrder order)
        {
            this.order = order;
        }

        [HttpGet]
        [Route("get-all")]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var a = await this.order.GetAll();
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetAll method: {ex}");

                throw;
            }

        }

        [HttpGet]
        [Route("get-all-order-by-user-id")]

        public async Task<IActionResult> GetAllByUserID(string userID)
        {
            try
            {
                var a = await this.order.GetAllByUserId(userID);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetAllByUserID method: {ex}");

                throw;
            }

        }

        [HttpPost]
        [Route("delete-order")]

        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var a = await this.order.DeleteOrder(id);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the Delete method: {ex}");

                throw;
            }

        }

        [HttpDelete]
        [Route("delete-order-success")]

        public async Task<IActionResult> DeleteSuccess(string id)
        {
            try
            {
                var a = await this.order.DeleteOrderComplete(id);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the DeleteSuccess method: {ex}");

                throw;
            }

        }

        [HttpGet]
        [Route("get-by-id")]

        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var a = await this.order.GetOrderById(id);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetById method: {ex}");

                throw;
            }

        }

        [HttpGet]
        [Route("get-by-id-true")]

        public async Task<IActionResult> GetByIdTrue(string id)
        {
            try
            {
                var a = await this.order.GetOrderByStatusTrue(id);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetByIdTrue method: {ex}");

                throw;
            }

        }
        [HttpGet]
        [Route("get-by-id-false")]

        public async Task<IActionResult> GetByIdFalse(string id)
        {
            try
            {
                var a = await this.order.GetOrderByStatusFalse(id);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetOrderByStatusFalse method: {ex}");

                throw;
            }

        }
        
        [HttpGet]
        [Route("get-order-false-by-userid")]

        public async Task<IActionResult> GetOrderStatusFalseByUserId(string UserId)
        {
            try
            {
                var a = await this.order.GetOrderStatusFalseByUserId(UserId);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetOrderStatusFalseByUserId method: {ex}");

                throw;
            }

        }


        [HttpPost]
        [Route("create-new-order")]

        public async Task<IActionResult> CreateOrder(CreateOrderDTO order)
        {
            try
            {
                var a = await this.order.CreateNewOrder(order);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the CreateOrder method: {ex}");

                throw;
            }
        }

        

        [HttpPost]
        [Route("create-new-order-custome")]

        public async Task<IActionResult> CreateNewOrderCustome(CreateOrderCustomeDTO order)
        {
            try
            {
                var a = await this.order.CreateNewOrderCustome(order);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the CreateNewOrderCustome method: {ex}");

                throw;
            }
        }


        [HttpPost]
            [Route("update-order")]

            public async Task<IActionResult> UpdateOrder(string order)
            {
                try
                {
                    var a = await this.order.UpdateOrder(order);
                    if (a == null)
                    {
                        return NotFound();
                    }
                    return Ok(a);
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"An error occurred in the UpdateOrder method: {ex}");

                    throw;
                }

            }
    }
}
