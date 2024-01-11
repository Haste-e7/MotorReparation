using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorReparation.Domain;
using MotorReparation.Infrastructure;

namespace MotorReparation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartUnitController : ControllerBase
    {
        private readonly MotorReparationDbContext _context;
        public PartUnitController(MotorReparationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.PartUnits.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(PartUnit PartUnit)
        {
            await _context.PartUnits.AddAsync(PartUnit);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return Ok(PartUnit.Id);
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var lu = await _context.PartUnits.FirstOrDefaultAsync(x => x.Id == id);
            if (lu == null)
                return BadRequest();
            else
            {
                _context.PartUnits.Remove(lu);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
