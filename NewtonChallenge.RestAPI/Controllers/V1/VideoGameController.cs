using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewtonChallenge.BusinessLayer.VideoGameServices;
using NewtonChallenge.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewtonChallenge.RestAPI.Controllers.V1
{
    [Route("api/v{version:apiVersion}/video-games-catalog")]
    [ApiVersion("1")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly IVideoGameService _videoGameService;

        public VideoGameController(IVideoGameService videoGameService)
        {
            this._videoGameService = videoGameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoGamesDto>>> GetCatalogAsync()
        {
            try
            {
                var videoGameList = await _videoGameService.GetAllVideoGamesAsync();

                return Ok(videoGameList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGameDto>> GetVideoGameAsync(int id)
        {
            try
            {
                var videoGame = await _videoGameService.GetVideoGameAsync(id);

                return Ok(videoGame);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateVideoGameAsync(VideoGameDto videoGame)
        {
            // first see if the id exists
            // TODO: Model verification and logging into NLog - too tired now
            var existingVideoGame = await _videoGameService.GetVideoGameDAOAsync(videoGame.VideoGameId);

            if(existingVideoGame is null)
            {
                return BadRequest("Cannot update a non-existing video game");
            }
            // I like to change the existing model.  Alternatively, this can be mapped also.
            existingVideoGame.Title = videoGame.Title;
            existingVideoGame.Price = videoGame.Price;
            existingVideoGame.ReleaseDate = videoGame.ReleaseDate;
            existingVideoGame.GenreId = videoGame.GenreId;
            existingVideoGame.RatingId = videoGame.RatingId;

            await _videoGameService.UpdateVideoGameAsync(existingVideoGame);

            return Ok();
        }

    }
}
