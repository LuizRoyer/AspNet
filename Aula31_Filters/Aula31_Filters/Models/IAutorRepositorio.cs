using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aula31_Filters.Models
{
    public interface IAutorRepositorio
    {
        Task<Autor> GetByIdAsync(int id);
        Task<List<Autor>> ListAsync();
        Task UpdateAsync(Autor autor);
        Task AddAsync(Autor autor);
        Task DeleteAsync(int id);
    }
}
