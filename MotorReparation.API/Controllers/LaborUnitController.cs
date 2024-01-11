using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorReparation.Domain;
using MotorReparation.Infrastructure;

namespace MotorReparation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaborUnitController : ControllerBase
    {
        private readonly MotorReparationDbContext _context;
        public LaborUnitController(MotorReparationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.LaborUnits.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(LaborUnit laborUnit)
        {
            await _context.LaborUnits.AddAsync(laborUnit);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            { 
                return Ok(laborUnit.Id); 
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var lu = await _context.LaborUnits.FirstOrDefaultAsync(x => x.Id == id);
            if (lu == null)
                return BadRequest();
            else
            {
                _context.LaborUnits.Remove(lu);
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
