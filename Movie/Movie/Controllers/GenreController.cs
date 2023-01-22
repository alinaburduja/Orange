using Microsoft.AspNetCore.Mvc;
using Orange.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orange.Api.Controllers
{
    [ApiController]
    [Route("genre")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpGet]
        public async Task<IEnumerable<int>> GetFivePopularGenre()
        {
            return (await genreService.GetFivePopularGenre()).ToList();
        }
    }
}
