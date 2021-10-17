using NewtonChallenge.DataAccessObjects.Interfaces;
using System.Threading.Tasks;

namespace NewtonChallenge.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbFactory _dbFactory;

        public UnitOfWork(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        Task<int> IUnitOfWork.CommitAsync()
        {
            return _dbFactory.DbContext.SaveChangesAsync();
        }
    }
}

