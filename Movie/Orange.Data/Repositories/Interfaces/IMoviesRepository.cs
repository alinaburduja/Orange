using Orange.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orange.Data.Repositories.Interfaces
{
    public interface IMoviesRepository
    {
        Task Add(Movie movie);
        Task<IEnumerable<Movie>> GetAll(int page, int pageSize);
        Task<IEnumerable<Movie>> Get();
        Task<IEnumerable<Movie>> GetTopRated();
        Task<Movie> GetMovieById(Guid id);
    }
}
