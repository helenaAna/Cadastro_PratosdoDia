using Microsoft.EntityFrameworkCore;
using PratoDoDia.Interfaces;
using PratoDoDia.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PratoDoDia.Repositories
{
    public class PratoRepositorio : IPratoRepositorio
    {

        public async Task<List<Prato>> Get()
        {
            using PRATODIAContext _context = new PRATODIAContext();
            return await _context.Prato.ToListAsync();
        }

        public async Task<Prato> Get(int id)
        {
            using PRATODIAContext _context = new PRATODIAContext();
            return await _context.Prato.FindAsync(id);
        }

        public async Task<Prato> Post(Prato prato)
        {
            using PRATODIAContext _context = new PRATODIAContext();
            await _context.AddAsync(prato);
            await _context.SaveChangesAsync();
            return prato;
        }

        public async Task<Prato> Put(Prato prato)
        {
            using (PRATODIAContext _context = new PRATODIAContext())
            {
                _context.Entry(prato).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return prato;
        }

        public async Task<Prato> Delete(Prato prato)
        {
            using PRATODIAContext _context = new PRATODIAContext();
            _context.Prato.Remove(prato);
            await _context.SaveChangesAsync();
            return prato;
        }
    }
}
