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
    public class CafeteriasController : ControllerBase
    {
        private readonly ICafeteria _Cafeteria;

        public CafeteriasController(ICafeteria CafeteriaRepository)
        {
            _Cafeteria = CafeteriaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cafeteria Cafeteria)
        {
            var id = await _Cafeteria.Create(Cafeteria);

            return new JsonResult(id.ToString());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var Cafeteria = await _Cafeteria.Get(ObjectId.Parse(id));

            return new JsonResult(Cafeteria);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Cafeteria = await _Cafeteria.Get();

            return new JsonResult(Cafeteria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Cafeteria Cafeteria)
        {
            var result = await _Cafeteria.Update(ObjectId.Parse(id), Cafeteria);

            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _Cafeteria.Delete(ObjectId.Parse(id));

            return new JsonResult(result);
        }
    }
}
