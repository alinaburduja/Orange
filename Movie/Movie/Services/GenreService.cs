using Orange.Api.Services.Interfaces;
using Orange.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orange.Api.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public  async Task<IEnumerable<int>> GetFivePopularGenre()
        {
            return await genreRepository.GetFivePopularGenre();
        }
    }
}
