using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafeteriasController : ControllerBase
    {
        private readonly CafeteriaContext _context;

        public CafeteriasController(CafeteriaContext context)
        {
            _context = context;
        }

        // GET: api/Cafeterias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cafeteria>>> GetCafeterias()
        {
          if (_context.Cafeterias == null)
          {
              return NotFound();
          }
            return await _context.Cafeterias.ToListAsync();
        }

        // GET: api/Cafeterias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cafeteria>> GetCafeteria(int id)
        {
          if (_context.Cafeterias == null)
          {
              return NotFound();
          }
            var cafeteria = await _context.Cafeterias.FindAsync(id);

            if (cafeteria == null)
            {
                return NotFound();
            }

            return cafeteria;
        }

        // PUT: api/Cafeterias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCafeteria(int id, Cafeteria cafeteria)
        {
            if (id != cafeteria.Id)
            {
                return BadRequest();
            }

            _context.Entry(cafeteria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CafeteriaExists(id))
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

        // POST: api/Cafeterias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cafeteria>> PostCafeteria(Cafeteria cafeteria)
        {
          if (_context.Cafeterias == null)
          {
              return Problem("Entity set 'CafeteriaContext.Cafeterias'  is null.");
          }
            _context.Cafeterias.Add(cafeteria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCafeteria", new { id = cafeteria.Id }, cafeteria);
        }

        // DELETE: api/Cafeterias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCafeteria(int id)
        {
            if (_context.Cafeterias == null)
            {
                return NotFound();
            }
            var cafeteria = await _context.Cafeterias.FindAsync(id);
            if (cafeteria == null)
            {
                return NotFound();
            }

            _context.Cafeterias.Remove(cafeteria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CafeteriaExists(int id)
        {
            return (_context.Cafeterias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
