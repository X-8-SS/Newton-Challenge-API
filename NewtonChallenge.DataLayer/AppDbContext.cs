using Microsoft.EntityFrameworkCore;
using NewtonChallenge.DataAccessObjects.Entities;

namespace NewtonChallenge.DataLayer
{
    public partial class AppDbContext : DbContext
    {
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}

