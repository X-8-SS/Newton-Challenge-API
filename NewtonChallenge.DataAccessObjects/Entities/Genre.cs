using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewtonChallenge.DataAccessObjects.Entities
{
    public class Genre
    {
        public Genre()
        {
            VideoGames = new HashSet<VideoGame>();
        }

        /// <summary>
        /// Properties
        /// </summary>
        [Key]
        public int GenreId { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }
        public ICollection<VideoGame> VideoGames { get; set; }
    }
}
