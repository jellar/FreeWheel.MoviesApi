using System.ComponentModel.DataAnnotations;

namespace FreeWheel.MoviesApi.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(128)]
        public string Surname { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
    }
}