using System.ComponentModel.DataAnnotations;

namespace NewtonChallenge.DataTransferObjects
{
    public class GenreDto
    {
        public int GenreId { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }
    }
}
