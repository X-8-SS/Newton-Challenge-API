using NewtonChallenge.DataAccessObjects.Entities;
using NewtonChallenge.DataAccessObjects.Interfaces;

namespace NewtonChallenge.DataLayer.Repositories
{
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        public RatingRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
