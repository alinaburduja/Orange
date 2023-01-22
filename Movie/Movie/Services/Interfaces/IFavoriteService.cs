using Orange.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orange.Api.Services.Interfaces
{
    public interface IFavoriteService
    {
        Task Add(Guid Id);
        Task Remove(Guid movieId);
        Task<Favorite> GetFavoriteById(Guid id);
        Task<IEnumerable<Favorite>> GetAll();
    }
}
