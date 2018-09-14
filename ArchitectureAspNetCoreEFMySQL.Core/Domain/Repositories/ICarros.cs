using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArchitectureAspNetCoreEFMySQL.Core.Domain.Repositories
{
    public interface ICarros
    {
        Task<IEnumerable<Entities.Carro>> GetAllAsync();
        Task<Entities.Carro> GetByIdAsync(int? id);
        Task Add(Entities.Carro carro);
        Task Edit(Entities.Carro carro);
        Task Delete(int id);
        bool Exists(int id);
    }
}
