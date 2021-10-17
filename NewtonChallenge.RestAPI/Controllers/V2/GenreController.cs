using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewtonChallenge.BusinessLayer.GenreServices;
using NewtonChallenge.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewtonChallenge.RestAPI.Controllers.V2
{
    [Route("api/v{version:apiVersion}/video-games-genre")]
    [ApiVersion("2")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            this._genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenreAsync()
        {
            try
            {
                var genreList = await _genreService.GetAllGenreAsync();

                return Ok(genreList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());
            }
        }

    }
}
