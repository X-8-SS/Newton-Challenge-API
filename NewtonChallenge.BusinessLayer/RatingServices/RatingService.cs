using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewtonChallenge.DataLayer;
using NewtonChallenge.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewtonChallenge.BusinessLayer.RatingServices
{
    public class RatingService : IRatingService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<RatingService> _logger;

        public RatingService(AppDbContext context,
            IMapper mapper,
            ILogger<RatingService> logger)
        {
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
        }

        public async Task<List<RatingDto>> GetAllRatingAsync()
        {
            var ratings = await _context.Ratings.ToListAsync();
            return _mapper.Map<List<RatingDto>>(ratings);
        }

    }
}
