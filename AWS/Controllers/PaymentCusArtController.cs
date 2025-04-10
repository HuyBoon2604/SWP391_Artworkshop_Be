using AWS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentCusArtController : ControllerBase
    {
        private readonly IPaymentCusArt paymentCusArt;

        public PaymentCusArtController(IPaymentCusArt paymentCusArt)
        {
            this.paymentCusArt = paymentCusArt;
        }

        [HttpGet]
        [Route("get-all")]

        public async Task<IActionResult> GetPaymentList()
        {
            try
            {
                var a = await this.paymentCusArt.GetPaymentList();
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetPaymentList method: {ex}");

                throw;
            }

        }

        [HttpPost]
        [Route("Create-New-Payment-CusArt")]

        public async Task<IActionResult> CreateNewPaymentCusArt(string OrderCusId)
        {
            try
            {
                var a = await this.paymentCusArt.CreateNewPaymentCusArt(OrderCusId);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the CreateNewPaymentCusArt method: {ex}");

                throw;
            }

        }
    }
}
