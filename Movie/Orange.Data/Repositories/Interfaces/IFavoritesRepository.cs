using Orange.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orange.Data.Repositories.Interfaces
{
    public interface IFavoritesRepository
    {
        Task<Favorite> GetByMovieId(Guid movieId);
        Task Add(Guid movieId);
        Task Remove(Guid movieId);
        Task<Favorite> GetFavoriteById(Guid id);
        Task<IEnumerable<Favorite>> GetAll();
    }
}
