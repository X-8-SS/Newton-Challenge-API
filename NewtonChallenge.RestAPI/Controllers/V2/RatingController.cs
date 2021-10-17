using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewtonChallenge.BusinessLayer.RatingServices;
using NewtonChallenge.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtonChallenge.RestAPI.Controllers.V2
{
    [Route("api/v{version:apiVersion}/video-games-rating")]
    [ApiVersion("2")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            this._ratingService = ratingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingDto>>> GetGenreAsync()
        {
            try
            {
                var ratingList = await _ratingService.GetAllRatingAsync();                

                return Ok(ratingList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());
            }
        }
    }
}
