using FreeWheel.MoviesApi.Dtos;
using FreeWheel.MoviesApi.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FreeWheel.MoviesApi.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly IMovieService _service;
        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        public HttpResponseMessage Get(int year = 0, string title = "", string genre = "")
        {
            if (year == 0 && string.IsNullOrEmpty(title) && string.IsNullOrEmpty(genre))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid movie search.");
            }
            var movies = _service.GetMovies(year, title, genre);


            return movies.Count == 0 ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Movies found with your search criteria.") : Request.CreateResponse(HttpStatusCode.OK, movies);
        }

        [Route("api/movies/top")]
        public HttpResponseMessage GetTopMovies()
        {
            var top5Movies = _service.GetTopMovies();
            return top5Movies.Count == 0 ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "No movies found.") : Request.CreateResponse(HttpStatusCode.OK, top5Movies);
        }

        [HttpPost]
        [Route("api/movies/rating")]
        public HttpResponseMessage PostRating([FromBody] UserRatingDto data)
        {
            if (!ModelState.IsValid) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid rating value.");
            bool status = _service.PostMyRating(data);
            if (status)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "movie/user is not found.");
        }
    }
}
