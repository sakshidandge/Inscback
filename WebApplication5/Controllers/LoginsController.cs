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
    public class LoginsController : ControllerBase
    {
        private readonly Insurance_74052Context _context;

        public LoginsController(Insurance_74052Context context)
        {
            _context = context;
        }

        // GET: api/Logins
        [HttpGet]
        public IEnumerable<Login> GetLogin()
        {
            return _context.Login;
        }

        // GET: api/Logins/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var login = await _context.Login.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }

        [HttpGet("details/{username}")]
        public async Task<IActionResult> GetUsername([FromRoute] string username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var login = await _context.Login.Where(x => x.Username == username).FirstOrDefaultAsync();

            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }

        [HttpGet("{id}/{password}")]

        public async Task<ActionResult<int>> GetByUsername(int id, string password)
        {
            var emp = await _context.Login.Where(x => x.Empid == id && x.Password == password).FirstAsync();

            if (emp == null)
            {
                return 0;
            }

            return 1;

        }


        // PUT: api/Logins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin([FromRoute] int id, [FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != login.Empid)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
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



        // POST: api/Logins
        [HttpPost]
        public async Task<IActionResult> PostLogin([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Login.Add(login);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogin", new { id = login.Empid }, login);
        }

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Login.Remove(login);
            await _context.SaveChangesAsync();

            return Ok(login);
        }

        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.Empid == id);
        }
    }
}