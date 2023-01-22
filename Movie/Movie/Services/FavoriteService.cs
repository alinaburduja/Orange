using Orange.Api.Services.Interfaces;
using Orange.Data.Entities;
using Orange.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orange.Api.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoritesRepository favoritesRepository;

        public FavoriteService(IFavoritesRepository favoritesRepository)
        {
            this.favoritesRepository = favoritesRepository;
        }

        public async Task Add(Guid movieId)
        {
            await favoritesRepository.Add(movieId);
        }

        public async Task<IEnumerable<Favorite>> GetAll()
        {
            return await favoritesRepository.GetAll();
        }

        public async Task<Favorite> GetFavoriteById(Guid id)
        {
            return await favoritesRepository.GetFavoriteById(id);
        }

        public async Task Remove(Guid movieId)
        {
            await favoritesRepository.Remove(movieId);
        }
    }
}
