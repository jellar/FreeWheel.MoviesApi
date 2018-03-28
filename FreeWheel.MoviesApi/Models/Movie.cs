using System.ComponentModel.DataAnnotations;

namespace FreeWheel.MoviesApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public int RunningTime { get; set; }
        public string Genre { get; set; }
    }
}