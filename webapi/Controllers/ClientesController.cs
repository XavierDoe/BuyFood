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
    [Route("/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ICliente _context;

        public ClientesController(ICliente context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente Cliente)
        {
            var id = await _context.Create(Cliente);

            return new JsonResult(id.ToString());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var Cliente = await _context.Get(ObjectId.Parse(id));

            return new JsonResult(Cliente);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Cliente = await _context.Get();

            return new JsonResult(Cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Cliente Cliente)
        {
            var result = await _context.Update(ObjectId.Parse(id), Cliente);

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
