using Orange.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orange.Data.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        Task<IEnumerable<int>> GetFivePopularGenre();
    }
}
