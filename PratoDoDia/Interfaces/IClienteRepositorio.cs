using PratoDoDia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PratoDoDia.Interfaces
{
    interface IClienteRepositorio
    {
        Task<List<Cliente>> Get();

        Task<Cliente> Get(int id);

        Task<Cliente> Post(Cliente cliente);

        Task<Cliente> Put(Cliente cliente);

        Task<Cliente> Delete(Cliente cliente);
    }
}
