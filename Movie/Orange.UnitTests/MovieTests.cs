using Moq;
using Orange.Api.Services;
using Orange.Data.Entities;
using Orange.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Orange.UnitTests
{
    public class MovieTests
    {
        [Fact]
        public async Task GetAllAsyncIsNotEmpty()
        {
            var mock = new Mock<IMoviesRepository>();
            var movies = new List<Movie>()
             {
                     new Movie()
                     {
                         Id = Guid.Parse("0BA5CD9E-19E9-4E03-EEAF-08DAFB29DBB1"),
                         BackdropPath = "/r9PkFnRUIthgBp2JZZzD380MWZy.jpg",
                         Adult = false,
                         ExternalId = 315162,
                         OriginalLanguage = "en",
                         OriginalTitle = "Puss in Boots: The Last Wish",
                         Overview = "Puss in Boots discovers that his passion for adventure has taken its toll: He has burned through eight of his nine lives, leaving him with only one life left. Puss sets out on an epic journey to find the mythical Last Wish and restore his nine lives.",
                         Popularity= 9062.029,
                         PosterPath = "/kuf6dutpsT0vSVehic3EZIqkOBt.jpg",
                         ReleaseDate = "2022-12-07",
                         Title = "Puss in Boots: The Last Wish",
                         Video = false,
                         VoteAverage = 8.6,
                         VoteCount = 2077,
                         Genres = new List<Genre>{ new Genre { Id = Guid.Parse("D25ADAC9-D883-4A88-A549-08DAFB29DBBE"), ExternalId =  2} }
                     }
             };

            mock.Setup(m => m.GetAll(1, 10)).Returns(Task.FromResult(movies.AsEnumerable()));

            var movieService = new MovieService(mock.Object);

            var result = (await movieService.GetAll(new Api.Models.Requests.PaginationRequest { Page = 1, PageSize = 10 })).ToList().FirstOrDefault();

            Assert.Equal(result.Title, movies.FirstOrDefault().Title);
        }

        [Fact]
        public async Task GetAllAsyncIsEmpty()
        {
            var mock = new Mock<IMoviesRepository>();

            mock.Setup(m => m.GetAll(1, 10)).Returns(Task.FromResult((new List<Movie> { }).AsEnumerable()));

            var movieService = new MovieService(mock.Object);

            var result = (await movieService.GetAll(new Api.Models.Requests.PaginationRequest { Page = 1, PageSize = 10 })).ToList();

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetByIdWithSuccess()
        {
            var mock = new Mock<IMoviesRepository>();
            var movies = new List<Movie>()
             {
                     new Movie()
                     {
                         Id = Guid.Parse("0BA5CD9E-19E9-4E03-EEAF-08DAFB29DBB1"),
                         BackdropPath = "/r9PkFnRUIthgBp2JZZzD380MWZy.jpg",
                         Adult = false,
                         ExternalId = 315162,
                         OriginalLanguage = "en",
                         OriginalTitle = "Puss in Boots: The Last Wish",
                         Overview = "Puss in Boots discovers that his passion for adventure has taken its toll: He has burned through eight of his nine lives, leaving him with only one life left. Puss sets out on an epic journey to find the mythical Last Wish and restore his nine lives.",
                         Popularity= 9062.029,
                         PosterPath = "/kuf6dutpsT0vSVehic3EZIqkOBt.jpg",
                         ReleaseDate = "2022-12-07",
                         Title = "Puss in Boots: The Last Wish",
                         Video = false,
                         VoteAverage = 8.6,
                         VoteCount = 2077,
                         Genres = new List<Genre>{ new Genre { Id = Guid.Parse("D25ADAC9-D883-4A88-A549-08DAFB29DBBE"), ExternalId =  2} }
                     }
             };

            mock.Setup(m => m.GetMovieById(It.IsAny<Guid>()))
                    .Returns(Task.FromResult(movies.AsEnumerable().FirstOrDefault()));

            var movieService = new MovieService(mock.Object);

            var result = (await movieService.GetMovieById(Guid.Parse("0BA5CD9E-19E9-4E03-EEAF-08DAFB29DBB1")));

            Assert.Equal(result.Title, movies.FirstOrDefault().Title);
        }

        [Fact]
        public async Task GetByIdWithoutSucces()
        {
            var mock = new Mock<IMoviesRepository>();

            mock.Setup(m => m.GetMovieById(It.IsAny<Guid>())).Returns(Task.FromResult((new List<Movie> { }).AsEnumerable().FirstOrDefault()));

            var movieService = new MovieService(mock.Object);

            var result = (await movieService.GetMovieById(Guid.Parse("0BA5CD9E-19E9-4E03-EEAF-08DAFB29DBB1")));

            Assert.Null(result);
        }
    }
}
