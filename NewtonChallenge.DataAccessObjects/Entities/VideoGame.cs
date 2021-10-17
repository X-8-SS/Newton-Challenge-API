using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewtonChallenge.DataAccessObjects.Entities
{
    public class VideoGame
    {
        /// <summary>
        /// Properties
        /// </summary>
        [Key]
        public int VideoGameId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public int GenreId { get; set; }
        public Genre Genres { get; set; }
        public int RatingId { get; set; }
        public Rating Ratings { get; set; }
    }
}
