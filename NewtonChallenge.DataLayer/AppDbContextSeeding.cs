using Microsoft.EntityFrameworkCore;
using NewtonChallenge.DataAccessObjects.Entities;
using System;

namespace NewtonChallenge.DataLayer
{
    public partial class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenreId);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.RatingId);
            });

            modelBuilder.Entity<VideoGame>(entity =>
            {
                entity.HasKey(e => e.VideoGameId);

                entity.Property(e => e.GenreId)
                    .HasColumnName("GenreId")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RatingId)
                    .HasColumnName("RatingId")
                    .HasDefaultValueSql("((6))");

                entity.HasOne(g => g.Genres)
                    .WithMany(v => v.VideoGames)
                    .HasForeignKey(g => g.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(g => g.Genres)
                    .WithMany(v => v.VideoGames)
                    .HasForeignKey(g => g.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(r => r.Ratings)
                    .WithMany(v => v.VideoGames)
                    .HasForeignKey(r => r.RatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Genre>()
                .HasData(
                    new Genre { GenreId = 1, Name = "Action games" },
                    new Genre { GenreId = 2, Name = "Platform games" },
                    new Genre { GenreId = 3, Name = "Shooter games" },
                    new Genre { GenreId = 4, Name = "Fighting games" },
                    new Genre { GenreId = 5, Name = "Stealth game" },
                    new Genre { GenreId = 6, Name = "Survival games" },
                    new Genre { GenreId = 7, Name = "Rhythm games" },
                    new Genre { GenreId = 8, Name = "Battle Royale games" }
                    );

            modelBuilder.Entity<Rating>()
                .HasData(
                    new Rating { RatingId = 1, Category = "E", Description = "Everyone" },
                    new Rating { RatingId = 2, Category = "E10+", Description = "Everyone 10+" },
                    new Rating { RatingId = 3, Category = "T", Description = "Teen" },
                    new Rating { RatingId = 4, Category = "M", Description = "Mature" },
                    new Rating { RatingId = 5, Category = "A", Description = "Adults" },
                    new Rating { RatingId = 6, Category = "RP", Description = "Rating Pending" }
                    );

            modelBuilder.Entity<VideoGame>()
                .HasData(
                    new VideoGame { VideoGameId = 1, Title = "Video game one", ReleaseDate = DateTime.Parse("2021-10-12"), GenreId = 1, Price = 20.00M, RatingId = 1 },
                    new VideoGame { VideoGameId = 2, Title = "Video game two", ReleaseDate = DateTime.Parse("2021-10-12"), GenreId = 2, Price = 24.00M, RatingId = 3 },
                    new VideoGame { VideoGameId = 3, Title = "Video game three", ReleaseDate = DateTime.Parse("2021-10-12"), GenreId = 3, Price = 27.00M, RatingId = 4 },
                    new VideoGame { VideoGameId = 4, Title = "Video game four", ReleaseDate = DateTime.Parse("2021-10-12"), GenreId = 4, Price = 30.00M, RatingId = 5 }
                    );
        }
    }
}
