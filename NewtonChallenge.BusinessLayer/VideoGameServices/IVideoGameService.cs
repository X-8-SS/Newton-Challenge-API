using NewtonChallenge.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewtonChallenge.BusinessLayer.VideoGameServices
{
    public interface IVideoGameService
    {
        Task<List<VideoGamesDto>> GetAllVideoGamesAsync();
        Task<VideoGameDto> GetVideoGameAsync(int id);
    }
}
