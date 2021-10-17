using AutoMapper;
using NewtonChallenge.DataAccessObjects.Entities;
using NewtonChallenge.DataTransferObjects;

namespace NewtonChallenge.BusinessLayer.MapperProfile
{
    public class NewtonChallengeProfile: Profile
    {
        public NewtonChallengeProfile()
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<Rating, RatingDto>();
            CreateMap<VideoGame, VideoGamesDto>();
            CreateMap<VideoGame, VideoGameDto>();
        }   
    }
}
