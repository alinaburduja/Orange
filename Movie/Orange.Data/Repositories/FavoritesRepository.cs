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
    public class FavoritesRepository : IFavoritesRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IMoviesRepository moviesRepository;

        public FavoritesRepository(AppDbContext dbContext, IMoviesRepository moviesRepository)
        {
            this.dbContext = dbContext;
            this.moviesRepository = moviesRepository;
        }

        public async Task<Favorite> GetByMovieId(Guid movieId)
        {
            return dbContext.Favorites.AsQueryable().Include(f => f.Movie).FirstOrDefault(m => m.Movie.Id == movieId);
        }

        public async Task Add(Guid movieId)
        {
            var favorite = await GetByMovieId(movieId);

            if (favorite is null)
            {
                var movie = await moviesRepository.GetMovieById(movieId);
                dbContext.Favorites.Add(new Favorite { Id = new Guid(), Movie = movie });
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task Remove(Guid movieId)
        {
            dbContext.Favorites.RemoveRange(dbContext.Favorites.Where(movie => movie.Movie.Id == movieId));

            await dbContext.SaveChangesAsync();
        }

        public async Task<Favorite> GetFavoriteById(Guid id)
        {
            return dbContext.Favorites.AsQueryable()
                 .Include(f => f.Movie).Where(f => f.Id == id).FirstOrDefault();
        }

        public async Task<IEnumerable<Favorite>> GetAll()
        {
            return dbContext.Favorites.AsQueryable()
                    .Include(f => f.Movie);
        }
    }
}
