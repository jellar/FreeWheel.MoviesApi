using FreeWheel.MoviesApi.Dtos;
using System.Collections.Generic;

namespace FreeWheel.MoviesApi.Services
{
    public interface IMovieService
    {
        List<MovieDto> GetMovies(int year, string title, string genre);

        List<MovieDto> GetTopMovies();

        List<MovieDto> GetMyTopMovies(int userId);

        bool PostMyRating(UserRatingDto rating);
    }
}
