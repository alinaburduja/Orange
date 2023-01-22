using Orange.Data.Entities;
using Orange.Data.Seeders.Models;
using System.Linq;

namespace Orange.Data.Seeders.Extensions
{
    public static class MappingExtensions
    {
        public static Movie ToEntity(this MovieDescription movieDescription)
        {
            return new Movie
            {
                Adult = movieDescription.Adult,
                BackdropPath = movieDescription.BackdropPath,
                ExternalId = movieDescription.Id,
                OriginalLanguage = movieDescription.OriginalLanguage,
                ReleaseDate = movieDescription.ReleaseDate,
                OriginalTitle = movieDescription.OriginalTitle,
                Overview = movieDescription.Overview,
                Popularity = movieDescription.Popularity,
                PosterPath = movieDescription.PosterPath,
                Title = movieDescription.Title,
                Video = movieDescription.Video,
                VoteAverage = movieDescription.VoteAverage,
                VoteCount = movieDescription.VoteCount,
                Genres = movieDescription.GenreIds?.Select(x => new Genre { ExternalId = x }).ToList()
            };
        }
    }
}
