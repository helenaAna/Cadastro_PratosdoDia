using PratoDoDia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PratoDoDia.Interfaces
{
    interface IVendaRepositorio
    {
        Task<List<Venda>> Get();

        Task<Venda> Get(int id);

        Task<Venda> Post(Venda venda);

        Task<Venda> Put(Venda venda);

        Task<Venda> Delete(Venda venda);
    }
}
