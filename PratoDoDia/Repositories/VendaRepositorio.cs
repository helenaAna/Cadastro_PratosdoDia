using Microsoft.EntityFrameworkCore;
using PratoDoDia.Interfaces;
using PratoDoDia.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PratoDoDia.Repositories
{
    public class VendaRepositorio : IVendaRepositorio
    {
        
        public async Task<List<Venda>> Get()
        {
            using PRATODIAContext _contexto = new PRATODIAContext();
            return await _contexto.Venda.Include("Cliente")
                                        .Include("Prato")
                                        .ToListAsync();
        }

        public async Task<Venda> Get(int id)
        {
            using PRATODIAContext _contexto = new PRATODIAContext();
            return await _contexto.Venda.Include("Cliente")
                                        .Include("Prato")
                                        .FirstOrDefaultAsync(e => e.IdVenda == id);
        }

        public async Task<Venda> Post(Venda venda)
        {
            using PRATODIAContext _context = new PRATODIAContext();
            await _context.AddAsync(venda);
            await _context.SaveChangesAsync();
            return venda;
        }

        public async Task<Venda> Put(Venda venda)
        {
            using (PRATODIAContext _context = new PRATODIAContext())
            {
                _context.Entry(venda).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return venda;
        }
        public async Task<Venda> Delete(Venda venda)
        {
            using (PRATODIAContext _contexto = new PRATODIAContext())
            {
                _contexto.Venda.Remove(venda);
                await _contexto.SaveChangesAsync();
            }
            return venda;
        }
    }
}
