using System.Runtime.Serialization;

namespace FreeWheel.MoviesApi.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public int RunningTime { get; set; }
        [IgnoreDataMember]
        public string Genre { get; set; }
        public double AverageRating { get; set; }
        [IgnoreDataMember]
        public int UserId { get; set; }
    }
}