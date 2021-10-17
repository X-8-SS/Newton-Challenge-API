using System.Threading.Tasks;

namespace NewtonChallenge.DataAccessObjects.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
