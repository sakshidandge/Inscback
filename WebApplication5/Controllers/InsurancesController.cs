using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Working.Models;

namespace Working.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancesController : ControllerBase
    {
        private readonly Insurance_74052Context _context;

        public InsurancesController(Insurance_74052Context context)
        {
            _context = context;
        }

        // GET: api/Insurances
        [HttpGet]
        public IEnumerable<Insurance> GetInsurance()
        {
            return _context.Insurance;
        }

        // GET: api/Insurances/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInsurance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var insurance = await _context.Insurance.FindAsync(id);

            if (insurance == null)
            {
                return NotFound();
            }

            return Ok(insurance);
        }

        [HttpGet("{Empid}")]
        public async Task<IActionResult> GetInsuranceemp([FromRoute] int empid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var insurance = await _context.Insurance.FindAsync(empid);

            if (insurance == null)
            {
                return NotFound();
            }

            return Ok(insurance);
        }

        [HttpGet("details/{Empid}")]
        public async Task<IActionResult> Getid([FromRoute] int empid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var insurance = await _context.Insurance.Where(x => x.Empid == empid).FirstOrDefaultAsync();

            if (insurance == null)
            {
                return NotFound();
            }

            return Ok(insurance);
        }


        // PUT: api/Insurances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsurance([FromRoute] int id, [FromBody] Insurance insurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insurance.Insuranceid)
            {
                return BadRequest();
            }

            _context.Entry(insurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Insurances
        [HttpPost]
        public async Task<IActionResult> PostInsurance([FromBody] Insurance insurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Insurance.Add(insurance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsurance", new { id = insurance.Insuranceid }, insurance);
        }

        // DELETE: api/Insurances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var insurance = await _context.Insurance.FindAsync(id);
            if (insurance == null)
            {
                return NotFound();
            }

            _context.Insurance.Remove(insurance);
            await _context.SaveChangesAsync();

            return Ok(insurance);
        }

        private bool InsuranceExists(int id)
        {
            return _context.Insurance.Any(e => e.Insuranceid == id);
        }
    }
}