using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewtonChallenge.DataAccessObjects.Interfaces;
using NewtonChallenge.DataLayer;
using Microsoft.Extensions.Configuration;
using NewtonChallenge.DataLayer.Repositories;
using NewtonChallenge.BusinessLayer.GenreServices;
using NewtonChallenge.BusinessLayer.RatingServices;
using NewtonChallenge.BusinessLayer.VideoGameServices;

namespace NewtonChallenge.BusinessLayer.DependencyInjection
{
    public static class DependencyInjectionInitializer
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with Scoped lifetime
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("NewtonChallengeConnection"));
            }
            );

            services.AddScoped<Func<AppDbContext>>((provider) => () => provider.GetService<AppDbContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IGenreRepository, GenreRepository>()
                .AddScoped<IRatingRepository, RatingRepository>()
                .AddScoped<IVideoGameRepository, VideoGameRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IGenreService, GenreService>()
                .AddScoped<IRatingService, RatingService>()
                .AddScoped<IVideoGameService, VideoGameService>();
        }
    }
}