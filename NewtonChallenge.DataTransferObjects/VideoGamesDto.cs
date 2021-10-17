using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewtonChallenge.DataTransferObjects
{
    public class VideoGamesDto
    {
        public int VideoGameId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public int GenreId { get; set; }
        public int RatingId { get; set; }
        public string GenreName { get; set; }
        public string RatingCategory { get; set; }
    }
}
