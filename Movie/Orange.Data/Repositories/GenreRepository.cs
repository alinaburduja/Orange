using Orange.Data.Context;
using Orange.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orange.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext dbContext;

        public GenreRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<int>> GetFivePopularGenre()
        {
            return dbContext.Genres.AsQueryable().GroupBy(g => g.ExternalId).Where(g => g.Count() > 1)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key).Take(5); 
        }
    }
}
