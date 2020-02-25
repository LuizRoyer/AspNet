using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula31_Filters.Filtros;
using Aula31_Filters.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula31_Filters.Controllers
{
    [Produces("application/json")]
    [Route("api/Autores")]
    [ValidarModelo]
    public class AutoresController : Controller
    {
        private readonly IAutorRepositorio _context;
        public AutoresController(IAutorRepositorio autorRepositorio)
        {
            _context = autorRepositorio;
        }

        // GET :api/ Autores
        [HttpGet]
        public async Task<List<Autor>> Get()
        {
            return await _context.ListAsync();
        }

        //Get api/autores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if ((await _context.ListAsync()).All(a => a.Id != id))
            {
                return NotFound(id);
            }
            return Ok(await _context.GetByIdAsync(id));
        }
        //put api/autores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Autor autor)
        {
            if ((await _context.ListAsync()).All(a => a.Id != id))
            {
                return NotFound(id);
            }
            autor.Id = id;
            await _context.UpdateAsync(autor);
            return Ok();
        }
        //post APi/autores
        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] Autor autor)
        {
            await _context.AddAsync(autor);
            return Ok(autor);
        }
        //delete api/autores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if((await _context.ListAsync()).All(a=> a.Id != id))
            {
                return NotFound(id);
            }

            await _context.DeleteAsync(id);
            return Ok();
        }
    }
}