using NewtonChallenge.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewtonChallenge.BusinessLayer.RatingServices
{
    /// <summary>
    /// List of ratings used for video games
    /// </summary>
    public interface IRatingService
    {
        Task<List<RatingDto>> GetAllRatingAsync();
    }
}
