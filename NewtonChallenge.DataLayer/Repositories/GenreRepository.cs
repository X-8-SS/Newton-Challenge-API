using NewtonChallenge.DataAccessObjects.Entities;
using NewtonChallenge.DataAccessObjects.Interfaces;

namespace NewtonChallenge.DataLayer.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}