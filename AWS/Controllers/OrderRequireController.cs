using AWS.DTO;
using AWS.Models;
using AWS.Repositories.Interfaces;
using AWS.Repositories.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderRequireController : ControllerBase
    {
        private readonly IOrderRequire orderRequire;

        public OrderRequireController(IOrderRequire orderRequire)
        {
            this.orderRequire = orderRequire;
        }

        [HttpGet]
        [Route("get-all")]

        public async Task<IActionResult> GetAllOrderRequire()
        {
            try
            {
                var a = await this.orderRequire.GetAllOrderRequire();
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetAllOrderRequire method: {ex}");

                throw;
            }

        }
        
        [HttpGet]
        [Route("Get-Order-Require-By-ArtCustomeId")]

        public async Task<IActionResult> GetOrderRequireByArtCustomeId(string ArtCustomeId)
        {
            try
            {
                var a = await this.orderRequire.GetOrderRequireByArtCustomeId(ArtCustomeId);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetOrderRequireByArtCustomeId method: {ex}");

                throw;
            }

        }

        [HttpGet]
        [Route("Get-Order-Require-By-Id")]

        public async Task<IActionResult> GetOrderRequireById(string id)
        {
            try
            {
                var a = await this.orderRequire.GetOrderRequireById(id);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetOrderRequireById method: {ex}");

                throw;
            }

        }

        [HttpPost]
        [Route("Create-New-Order-Require")]

        public async Task<IActionResult> CreateNewOrderRequire(NewOrderRequireDTO order)
        {
            try
            {
                var a = await this.orderRequire.CreateNewOrderRequire(order);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the CreateNewOrderRequire method: {ex}");

                throw;
            }

        }

        [HttpDelete]
        [Route("Delete-by-OrderRequireID")]

        public async Task<IActionResult> Delete(string OrderRequireId)
        {
            try
            {
                var a = await this.orderRequire.Delette(OrderRequireId);
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


        [HttpPost]
        [Route("Update-Status-Order-Require")]

        public async Task<IActionResult> UpdateStatusOrderRequire(string OrderRequireId)
        {
            try
            {
                var a = await this.orderRequire.UpdateStatusOrderRequire(OrderRequireId);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the UpdateStatusOrderRequire method: {ex}");

                throw;
            }

        }
    }
}
