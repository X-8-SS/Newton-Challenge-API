using NewtonChallenge.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewtonChallenge.BusinessLayer.GenreServices
{
    public interface IGenreService
    {
        Task<List<GenreDto>> GetAllGenreAsync();
    }
}