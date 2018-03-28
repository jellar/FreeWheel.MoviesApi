using FreeWheel.MoviesApi.Models;
using System.ComponentModel.DataAnnotations;

namespace FreeWheel.MoviesApi.Dtos
{
    public class UserRatingDto
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [Range(1, 5)]
        public Rating Rating { get; set; }
    }
}