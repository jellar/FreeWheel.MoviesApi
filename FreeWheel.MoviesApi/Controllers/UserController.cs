using FreeWheel.MoviesApi.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FreeWheel.MoviesApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IMovieService _service;
        public UserController(IMovieService service)
        {
            _service = service;
        }

        [Route("api/{userId}/my-top-movies")]
        public HttpResponseMessage GetMyTopMovies(int userId)
        {
            var top5Movies = _service.GetMyTopMovies(userId);
            return top5Movies.Count == 0 ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "No movies found.") : Request.CreateResponse(HttpStatusCode.OK, top5Movies);
        }
    }
}
