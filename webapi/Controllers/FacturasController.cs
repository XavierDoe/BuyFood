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
    public class FacturasController : ControllerBase
    {
        private readonly FacturaContext _context;

        public FacturasController(FacturaContext context)
        {
            _context = context;
        }

        // GET: api/Facturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetTodoFacturas()
        {
          if (_context.TodoFacturas == null)
          {
              return NotFound();
          }
            return await _context.TodoFacturas.ToListAsync();
        }

        // GET: api/Facturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetFactura(int id)
        {
          if (_context.TodoFacturas == null)
          {
              return NotFound();
          }
            var factura = await _context.TodoFacturas.FindAsync(id);

            if (factura == null)
            {
                return NotFound();
            }

            return factura;
        }

        // PUT: api/Facturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, Factura factura)
        {
            if (id != factura.Id)
            {
                return BadRequest();
            }

            _context.Entry(factura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
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

        // POST: api/Facturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Factura>> PostFactura(Factura factura)
        {
          if (_context.TodoFacturas == null)
          {
              return Problem("Entity set 'FacturaContext.TodoFacturas'  is null.");
          }
            _context.TodoFacturas.Add(factura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactura", new { id = factura.Id }, factura);
        }

        // DELETE: api/Facturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            if (_context.TodoFacturas == null)
            {
                return NotFound();
            }
            var factura = await _context.TodoFacturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            _context.TodoFacturas.Remove(factura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturaExists(int id)
        {
            return (_context.TodoFacturas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
