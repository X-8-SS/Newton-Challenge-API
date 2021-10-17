using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewtonChallenge.DataAccessObjects.Entities
{
    public class Rating
    {
        public Rating()
        {
            VideoGames = new HashSet<VideoGame>();
        }

        // Properties
        [Key]
        public int RatingId { get; set; }

        [StringLength(5, MinimumLength = 1)]
        [Required]
        public string Category { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Description { get; set; }
        public ICollection<VideoGame> VideoGames { get; set; }
    }
}
