using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PratoDoDia.Models;

namespace PratoDoDia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly PRATODIAContext _context;

        public VendasController(PRATODIAContext context)
        {
            _context = context;
        }

        // GET: api/Vendas
        [HttpGet]
        public async Task<ActionResult<List<Venda>>> GetVenda()
        {
            var venda = await _context.Venda.Include(c => c.IdCliente)
                                            .Include(p => p.IdPrato).ToListAsync();

            if (venda == null)
            {
                return NotFound();
            }

            return venda;
        }

        // GET: api/Vendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
           
            var venda = await _context.Venda.Include(c => c.IdCliente)
                                            .Include(p => p.IdPrato)
                                            .FirstOrDefaultAsync(v => v.IdVenda == id);

            if (venda == null)
            {
                return NotFound();
            }

            return venda;
        }


        // PUT: api/Vendas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Venda venda)
        {
            if (id != venda.IdVenda)
            {
                return BadRequest();
            }

            _context.Entry(venda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var venda_valida = await _context.Prato.FindAsync(id);

                if (venda_valida == null)
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
        // POST: api/Vendas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Venda>> Post(Venda venda)
        {
            try
            {
                await _context.AddAsync(venda);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return venda;
        }

        // DELETE: api/Vendas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Venda>> Delete(int id)
        {
            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            _context.Venda.Remove(venda);
            await _context.SaveChangesAsync();

            return venda;
        }

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.IdVenda == id);
        }
    }
}
