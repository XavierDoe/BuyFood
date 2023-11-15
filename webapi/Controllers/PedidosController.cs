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
    public class PedidosController : ControllerBase
    {
        private readonly IPedido _context;

        public PedidosController(IPedido context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pedido Pedido)
        {
            var id = await _context.Create(Pedido);

            return new JsonResult(id.ToString());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var Pedido = await _context.Get(ObjectId.Parse(id));

            return new JsonResult(Pedido);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Pedido = await _context.Get();

            return new JsonResult(Pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Pedido Pedido)
        {
            var result = await _context.Update(ObjectId.Parse(id), Pedido);

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
