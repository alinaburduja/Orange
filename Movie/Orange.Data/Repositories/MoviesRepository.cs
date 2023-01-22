using Microsoft.EntityFrameworkCore;
using Orange.Data.Context;
using Orange.Data.Entities;
using Orange.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orange.Data.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly AppDbContext dbContext;

        public MoviesRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(Movie movie)
        {
            dbContext.Movies.Add(movie);

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> Get()
        {
            return dbContext.Movies.AsQueryable()
                     .Include(m => m.Genres);
        }

        public async Task<IEnumerable<Movie>> GetAll(int page, int pageSize)
        {
            return dbContext.Movies.AsQueryable()
                    .Include(m => m.Genres).OrderBy(m => m.Title).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public async Task<Movie> GetMovieById(Guid id)
        {
            return dbContext.Movies.AsQueryable()
                  .Include(m => m.Genres).Where(m => m.Id == id).FirstOrDefault();
        }

        public async Task<IEnumerable<Movie>> GetTopRated()
        {
            return dbContext.Movies.AsQueryable()
                    .Include(m => m.Genres).OrderByDescending(m => m.VoteAverage);
        }
    }
}
