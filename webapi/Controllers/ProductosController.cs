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
    public class ProductosController : ControllerBase
    {
        private readonly ProductoI _context;

        public ProductosController(ProductoI context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Producto Producto)
        {
            var id = await _context.Create(Producto);

            return new JsonResult(id.ToString());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var Producto = await _context.Get(ObjectId.Parse(id));

            return new JsonResult(Producto);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Producto = await _context.Get();

            return new JsonResult(Producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Producto Producto)
        {
            var result = await _context.Update(ObjectId.Parse(id), Producto);

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