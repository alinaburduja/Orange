using Orange.Api.Models.Results;
using Orange.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Orange.Api.Extensions
{
    public static class MappingExtensions
    {
        public static MovieDto ToDto(this Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Adult = movie.Adult,
                BackdropPath = movie.BackdropPath,
                ExternalId = movie.ExternalId,
                OriginalLanguage = movie.OriginalLanguage,
                OriginalTitle = movie.OriginalTitle,
                Overview = movie.Overview,
                Popularity = movie.Popularity,
                Video = movie.Video,
                PosterPath = movie.PosterPath,
                ReleaseDate = movie.ReleaseDate,
                Title = movie.Title,
                VoteAverage = movie.VoteAverage,
                VoteCount = movie.VoteCount,
                Genres = movie.Genres?.ToDto()
            };
        }

        public static GenreDto ToDto(this Genre genre)
        {
            return new GenreDto
            {
                ExternalId = genre.ExternalId,
                Id = genre.Id
            };
        }

        public static List<GenreDto> ToDto(this List<Genre> genres)
        {
            return genres.Select(g => g.ToDto()).ToList();
        }

        public static List<MovieDto> ToDto(this List<Movie> movies)
        {
            return movies.Select(m => m.ToDto()).ToList();
        }

        public static FavoriteDto ToDto(this Favorite favorite)
        {
            return new FavoriteDto
            {
                Id = favorite.Id,
                Movie = favorite.Movie.ToDto()
            };
        }

        public static List<FavoriteDto> ToDto(this List<Favorite> favorites)
        {
            return favorites.Select(f => f.ToDto()).ToList();
        }

        public static Dictionary<string, List<MovieDto>> ToDto(this Dictionary<int, List<Movie>> movies)
        {
            var result = new Dictionary<string, List<MovieDto>>();

            foreach (var pair in movies)
            {
                result.Add(pair.Key.ToString(), pair.Value.ToDto());
            }

            return result;
        }
    }
}
