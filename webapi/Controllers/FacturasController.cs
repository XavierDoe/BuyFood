using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly IFactura _context;

        public FacturasController(IFactura context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Factura Factura)
        {
            var id = await _context.Create(Factura);

            return new JsonResult(id.ToString());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var Factura = await _context.Get(ObjectId.Parse(id));

            return new JsonResult(Factura);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Factura = await _context.Get();

            return new JsonResult(Factura);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Factura Factura)
        {
            var result = await _context.Update(ObjectId.Parse(id), Factura);

            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _context.Delete(ObjectId.Parse(id));

            return new JsonResult(result);
        }
    }
}
