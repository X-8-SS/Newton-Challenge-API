using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewtonChallenge.DataAccessObjects.Entities;
using NewtonChallenge.DataLayer;
using NewtonChallenge.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewtonChallenge.BusinessLayer.VideoGameServices
{
    public class VideoGameService: IVideoGameService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<VideoGameService> _logger;

        public VideoGameService(
            AppDbContext context,
            IMapper mapper,
            ILogger<VideoGameService> logger
            )
        {
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
        }

        /// <inheritdoc />
        public async Task<List<VideoGamesDto>> GetAllVideoGamesAsync()
        {
            var videoGames = await _context.VideoGames.ToListAsync();
            var genres = await _context.Genres.ToListAsync();
            var ratings = await _context.Ratings.ToListAsync();

            var videoGamesDto = _mapper.Map<List<VideoGamesDto>>(videoGames);
            // construct the descriptions for genreId and ratingId
            foreach (var videoGame in videoGamesDto)
            {
                videoGame.GenreName = genres.Find(x => x.GenreId == videoGame.GenreId)?.Name ?? string.Empty;
                videoGame.RatingCategory = ratings.Find(x => x.RatingId == videoGame.RatingId)?.Category ?? string.Empty;
            }

            return videoGamesDto;
        }

        /// <inheritdoc />
        public async Task<VideoGameDto> GetVideoGameAsync(int id)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);           
            var videoGameDto = _mapper.Map<VideoGameDto>(videoGame);

            return videoGameDto;
        }

        /// <inheritdoc />
        public async Task<VideoGame> GetVideoGameDAOAsync(int id)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);

            return videoGame;
        }

        /// <inheritdoc />
        public async Task<bool> UpdateVideoGameAsync(VideoGame videoGame)
        {
            try
            {
                _context.VideoGames.Update(videoGame);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
            }            

            return true;
        }
    }
}
