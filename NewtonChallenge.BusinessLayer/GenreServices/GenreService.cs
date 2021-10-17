using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewtonChallenge.DataLayer;
using NewtonChallenge.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewtonChallenge.BusinessLayer.GenreServices
{
    public class GenreService: IGenreService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GenreService> _logger;

        public GenreService(AppDbContext context,
            IMapper mapper,
            ILogger<GenreService> logger)
        {
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
        }

        /// <inheritdoc />
        public async Task<List<GenreDto>> GetAllGenreAsync()
        {
            var genres = await _context.Genres.ToListAsync();
            return _mapper.Map<List<GenreDto>>(genres);
        }

    }
}
