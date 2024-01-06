using Microsoft.AspNetCore.Mvc;

namespace MotorReparation.API.Controllers
{
    public class TicketController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTicketById(int id)
        {
            return Ok();
        }
    }
}
