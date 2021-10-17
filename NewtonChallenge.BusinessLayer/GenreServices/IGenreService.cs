using NewtonChallenge.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewtonChallenge.BusinessLayer.GenreServices
{
    /// <summary>
    /// Gets list of ratings used for video games
    /// </summary>
    public interface IGenreService
    {
        Task<List<GenreDto>> GetAllGenreAsync();
    }
}