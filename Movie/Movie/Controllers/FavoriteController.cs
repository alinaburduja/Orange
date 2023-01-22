using Microsoft.AspNetCore.Mvc;
using Orange.Api.Extensions;
using Orange.Api.Models.Results;
using Orange.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orange.Api.Controllers
{
    [ApiController]
    [Route("favorites")]
    public class FavoriteController: ControllerBase
    {
        private readonly IFavoriteService favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            this.favoriteService = favoriteService;
        }

        [Route("{movieId}")]
        [HttpPost]
        public async Task Add([FromRoute] Guid movieId)
        {
            await favoriteService.Add(movieId);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task Remove([FromRoute] Guid id)
        {
            await favoriteService.Remove(id);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<FavoriteDto> GetFavoriteById([FromRoute] Guid id)
        {
            return (await favoriteService.GetFavoriteById(id)).ToDto();
        }

        [HttpGet]
        public async Task<IEnumerable<FavoriteDto>> GetAll()
        {
            return (await favoriteService.GetAll()).ToList().ToDto();
        }

    }
}
