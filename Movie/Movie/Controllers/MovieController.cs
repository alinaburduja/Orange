using Microsoft.AspNetCore.Mvc;
using Orange.Api.Extensions;
using Orange.Api.Models.Requests;
using Orange.Api.Models.Results;
using Orange.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orange.Api.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieDto>> GetAll([FromQuery] PaginationRequest paginationRequest)
        {
           return (await _movieService.GetAll(paginationRequest)).ToList().ToDto();
        }

        [Route("topRated")]
        [HttpGet]
        public async Task<IEnumerable<MovieDto>> GetTopRated()
        {
            return (await _movieService.GetTopRated()).ToList().ToDto();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<MovieDto> GetMovieById([FromRoute] Guid id)
        {
            return (await _movieService.GetMovieById(id)).ToDto();
        }

        [Route("topGenres")]
        [HttpGet]
        public async Task<Dictionary<string, List<MovieDto>>> GetMoviesByTopGenres()
        {
          return (await _movieService.GetMoviesByTopGenres()).ToDto();
        }
    }
}
