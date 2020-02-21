using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PratoDoDia.Models;

namespace PratoDoDia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratosController : ControllerBase
    {
        private readonly PRATODIAContext _context;

        public PratosController(PRATODIAContext context)
        {
            _context = context;
        }

        // GET: api/Pratos
        [HttpGet]
        public async Task<ActionResult<List<Prato>>> GetPrato()
        {
            var prato = await _context.Prato.ToListAsync();

            if (prato == null)
            {
                return NotFound();
            }

            return prato;
        }

        // GET: api/Pratos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prato>> GetPreto(int id)
        {
            var prato = await _context.Prato.FindAsync(id);

            if (prato == null)
            {
                return NotFound();
            }

            return prato;
        }

        // PUT: api/Pratos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Prato prato)
        {
            if (id != prato.IdPrato)
            {
                return BadRequest();
            }

            _context.Entry(prato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var prato_valido = await _context.Prato.FindAsync(id);

                if (prato_valido == null)
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

        // POST: api/Pratos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Prato>> Post(Prato prato)
        {
            try
            {
                await _context.AddAsync(prato);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return prato;
        }

        // DELETE: api/Pratos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prato>> Delete(int id)
        {
            var prato = await _context.Prato.FindAsync(id);
            if (prato == null)
            {
                return NotFound();
            }

            _context.Prato.Remove(prato);
            await _context.SaveChangesAsync();

            return prato;
        }


        private bool PratoExists(int id)
        {
            return _context.Prato.Any(e => e.IdPrato == id);
        }
    }
}
