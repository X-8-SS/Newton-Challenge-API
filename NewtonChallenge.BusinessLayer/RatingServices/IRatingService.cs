using NewtonChallenge.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewtonChallenge.BusinessLayer.RatingServices
{
    public interface IRatingService
    {
        Task<List<RatingDto>> GetAllRatingAsync();
    }
}
