using Microsoft.EntityFrameworkCore;
using PratoDoDia.Interfaces;
using PratoDoDia.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PratoDoDia.Repositories
{
    public class ClienteRepositorio : IClienteRepositorio
    {
       
        public async Task<List<Cliente>> Get()
        {
            using PRATODIAContext _context = new PRATODIAContext();
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente> Get(int id)
        {
            using PRATODIAContext _context = new PRATODIAContext();
            return await _context.Cliente.FindAsync(id);
        }

        public async Task<Cliente> Post(Cliente cliente)
        {
            using PRATODIAContext _context = new PRATODIAContext();
            await _context.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Put(Cliente cliente)
        {
            using (PRATODIAContext _context = new PRATODIAContext())
            {
                _context.Entry(cliente).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return cliente;
        }
        public async Task<Cliente> Delete(Cliente cliente)
        {
            using PRATODIAContext _context = new PRATODIAContext();
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
