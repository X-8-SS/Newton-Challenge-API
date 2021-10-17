﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewtonChallenge.BusinessLayer.GenreServices;
using NewtonChallenge.BusinessLayer.VideoGameServices;
using NewtonChallenge.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}