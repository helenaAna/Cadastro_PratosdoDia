using PratoDoDia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PratoDoDia.Interfaces
{
    interface IPratoRepositorio
    {
        Task<List<Prato>> Get();

        Task<Prato> Get(int id);

        Task<Prato> Post(Prato prato);

        Task<Prato> Put(Prato prato);

        Task<Prato> Delete(Prato prato);
    }
}
