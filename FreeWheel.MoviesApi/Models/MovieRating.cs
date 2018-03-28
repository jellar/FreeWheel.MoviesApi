
using System.ComponentModel.DataAnnotations;

namespace FreeWheel.MoviesApi.Models
{
    public class MovieRating
    {
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public Rating Rating { get; set; }
    }
    public enum Rating
    {
        OneStar = 1,
        TwoStar = 2,
        ThreeStar = 3,
        FourStar = 4,
        FiveStar = 5
    }
}