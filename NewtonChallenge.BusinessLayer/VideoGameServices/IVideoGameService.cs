using NewtonChallenge.DataAccessObjects.Entities;
using NewtonChallenge.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewtonChallenge.BusinessLayer.VideoGameServices
{
    public interface IVideoGameService
    {
        /// <summary>
        /// returns list of all video games
        /// </summary>
        /// <returns></returns>
        Task<List<VideoGamesDto>> GetAllVideoGamesAsync();

        /// <summary>
        /// returns requested video game
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<VideoGameDto> GetVideoGameAsync(int id);

        /// <summary>
        /// returns video game as entity object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<VideoGame> GetVideoGameDAOAsync(int id);

        /// <summary>
        /// Updates video game
        /// </summary>
        /// <param name="videoGame"></param>
        /// <returns></returns>
        Task<bool> UpdateVideoGameAsync(VideoGame videoGame);
    }
}
