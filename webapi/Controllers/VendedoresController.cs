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
    public class VendedoresController : ControllerBase
    {
        private readonly IVendedor _context;

        public VendedoresController(IVendedor context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vendedor Vendedor)
        {
            var id = await _context.Create(Vendedor);

            return new JsonResult(id.ToString());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var Vendedor = await _context.Get(ObjectId.Parse(id));

            return new JsonResult(Vendedor);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Vendedor = await _context.Get();

            return new JsonResult(Vendedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Vendedor Vendedor)
        {
            var result = await _context.Update(ObjectId.Parse(id), Vendedor);

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