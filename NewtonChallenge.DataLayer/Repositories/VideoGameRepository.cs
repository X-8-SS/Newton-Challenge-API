using NewtonChallenge.DataAccessObjects.Entities;
using NewtonChallenge.DataAccessObjects.Interfaces;

namespace NewtonChallenge.DataLayer.Repositories
{
    public class VideoGameRepository : Repository<VideoGame>, IVideoGameRepository
    {
        public VideoGameRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
