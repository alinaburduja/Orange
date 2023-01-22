using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orange.Api.Services.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<int>> GetFivePopularGenre();
    }
}
