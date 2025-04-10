using AWS.DTO;
using AWS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtCustomeController : ControllerBase
    {
        private readonly IArtCustome artCustome;

        public ArtCustomeController(IArtCustome artCustome)
        {
            this.artCustome = artCustome;
        }

        [HttpGet]
        [Route("get-all")]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var a = await this.artCustome.GetAllArtworkCustome();
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetAllArtworkCustome method: {ex}");

                throw;
            }

        }

        [HttpGet]
        [Route("get-custome-artwork-by-id")]

        public async Task<IActionResult> GetCustomeArtworkById(string id)
        {
            try
            {
                var a = await this.artCustome.GetCustomeArtworkById(id);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetCustomeArtworkById method: {ex}");

                throw;
            }

        }
        
        [HttpGet]
        [Route("get-custome-artwork-by-Userid")]

        public async Task<IActionResult> GetCustomeArtworkByUserId(string userid)
        {
            try
            {
                var a = await this.artCustome.GetCustomeArtworkByUserId(userid);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetCustomeArtworkByUserId method: {ex}");

                throw;
            }

        }

        [HttpPost]
        [Route("create-new-art-custome")]

        public async Task<IActionResult> CreateNewCustome(string userid, ArtCustomeDTO artcustome)
        {
            try
            {
                var a = await this.artCustome.CreateNewCustome(userid, artcustome);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the CreateNewCustome method: {ex}");

                throw;
            }

        }

        [HttpPost]
        [Route("update-status")]

        public async Task<IActionResult> Update(string userid)
        {
            try
            {
                var a = await this.artCustome.UpdateStaus(userid);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the Update method: {ex}");

                throw;
            }

        }

      [HttpPost]
        [Route("Update-Money-ArtCustome")]

        public async Task<IActionResult> UpdateMoneyArtCustome(string artid, decimal money)
        {
            try
            {
                var a = await this.artCustome.UpdateMoneyArtCustome(artid,money);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            } 
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the UpdateMoneyArtCustome method: {ex}");

                throw;
            }

        }

        [HttpDelete]
        [Route("delete")]

        public async Task<IActionResult> Delete(string userid)
        {
            try
            {
                var a = await this.artCustome.Delete(userid);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the delete method: {ex}");

                throw;
            }

        }
    }
}
