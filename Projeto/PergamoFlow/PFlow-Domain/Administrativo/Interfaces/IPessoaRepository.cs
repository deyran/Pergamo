using PFlow_Domain.Administrativo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PFlow_Domain.Administrativo.Interfaces
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> GetAllAsync();
        Task<Pessoa> GetByIdAsync(int id);
        Task AddAsync(Pessoa pessoa);
        Task UpdateAsync(Pessoa pessoa);
        Task DeleteAsync(int id);
    }
}
