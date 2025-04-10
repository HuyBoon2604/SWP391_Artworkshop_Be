using AWS.DTO;
using AWS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderCusArtController : ControllerBase
    {
        private readonly IOrderCusArt orderCusArt;

        public OrderCusArtController(IOrderCusArt orderCusArt)
        {
            this.orderCusArt = orderCusArt;
        }

        [HttpGet]
        [Route("get-all")]

        public async Task<IActionResult> GetAllOrderCusArte()
        {
            try
            {
                var a = await this.orderCusArt.GetAllOrderCusArte();
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetAllOrderCusArte method: {ex}");

                throw;
            }

        }

        [HttpGet]
        [Route("Get-OrderCusArt-By-Id")]

        public async Task<IActionResult> GetOrderCusArtById(string id)
        {
            try
            {
                var a = await this.orderCusArt.GetOrderCusArtById( id);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetOrderCusArtById method: {ex}");

                throw;
            }

        }

        [HttpPost]
        [Route("Create-New-OrderCusArt")]

        public async Task<IActionResult> CreateNewOrderCusArt(NewOrderCusArtDTO order, string ArtwokCustomeID)
        {
            try
            {
                var a = await this.orderCusArt.CreateNewOrderCusArt(order,ArtwokCustomeID);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the CreateNewOrderCusArt method: {ex}");

                throw;
            }

        }

        
        [HttpPost]
        [Route("UpdateStatuOrderCusArt")]

        public async Task<IActionResult> UpdateStatuOrderCusArt(string OrderRequireId)
        {
            try
            {
                var a = await this.orderCusArt.UpdateStatuOrderCusArt(OrderRequireId);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the UpdateStatuOrderCusArt method: {ex}");

                throw;
            }

        }
    }
}
