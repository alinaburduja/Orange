using Orange.Api.Models.Requests;
using Orange.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orange.Api.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAll(PaginationRequest paginationRequest);
        Task<IEnumerable<Movie>> GetTopRated();
        Task<Movie> GetMovieById(Guid id);
        Task<Dictionary<int, List<Movie>>> GetMoviesByTopGenres();
    }
}
