using Orange.Api.Models.Requests;
using Orange.Api.Services.Interfaces;
using Orange.Data.Entities;
using Orange.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orange.Api.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMoviesRepository moviesRepository;
        private readonly IGenreRepository genreRepository;

        public MovieService(IMoviesRepository moviesRepository, IGenreRepository genreRepository)
        {
            this.moviesRepository = moviesRepository;
            this.genreRepository = genreRepository;
        }

        public async Task<IEnumerable<Movie>> GetAll(PaginationRequest paginationRequest)
        {
            return await moviesRepository.GetAll(paginationRequest.Page, paginationRequest.PageSize);
        }

        public async Task<Movie> GetMovieById(Guid id)
        {
            return await moviesRepository.GetMovieById(id);
        }

        public async Task<Dictionary<int, List<Movie>>> GetMoviesByTopGenres()
        {
            var result = new Dictionary<int, List<Movie>>();

            var topGenres = (await genreRepository.GetFivePopularGenre()).ToList();
            var movies = (await moviesRepository.Get()).ToList();

            foreach (var topGenre in topGenres)
            {
                var genreMovies = new List<Movie>();

                foreach (var movie in movies)
                {
                    if (movie.Genres.Any(x => x.ExternalId == topGenre))
                    {
                        genreMovies.Add(movie);
                    }
                }

                result.Add(topGenre, genreMovies);
            }

            return result;
        }

        public async Task<IEnumerable<Movie>> GetTopRated()
        {
            return await moviesRepository.GetTopRated();
        }
    }
}
