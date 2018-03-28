using FreeWheel.MoviesApi.Data;
using FreeWheel.MoviesApi.Dtos;
using FreeWheel.MoviesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreeWheel.MoviesApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;
        public MovieService(ApplicationDbContext context)
        {
            _context = context;

        }

        public List<MovieDto> GetMovies(int year = 0, string title = "", string genre = "")
        {
            var query = GetMoviesWithRatings();
            var genreArray = genre.Split(',').Select(x => x.ToLowerInvariant());
            var filterByTitle = title.Trim().ToLowerInvariant();

            IEnumerable<string> enumerable = genreArray as string[] ?? genreArray.ToArray();
            if (enumerable.Count() > 1)
            {
                query = year > 0
                    ? query.Where(m => enumerable.Contains(m.Genre.ToLowerInvariant())
                                       && m.YearOfRelease == year
                                       && m.Title.ToLowerInvariant().Contains(filterByTitle))
                    : query.Where(m => enumerable.Contains(m.Genre.ToLowerInvariant())
                                       && m.Title.ToLowerInvariant().Contains(filterByTitle));
            }
            else
            {
                query = year > 0
                    ? query.Where(m => m.Genre.ToLowerInvariant().Contains(genre) && m.YearOfRelease == year
                                       && m.Title.ToLowerInvariant().Contains(filterByTitle))
                    : query.Where(m => m.Genre.ToLowerInvariant().Contains(genre)
                                       && m.Title.ToLowerInvariant().Contains(filterByTitle));
            }
            return query.ToList();
        }


        private IEnumerable<MovieDto> GetMoviesWithRatings()
        {
            var query = _context.MovieRatings.Join(_context.Movies, r => r.MovieId, m => m.Id, (r, m) => new
            {
                r.Rating,
                r.MovieId,
                m.Title,
                m.Id,
                m.YearOfRelease,
                m.RunningTime,
                m.Genre
            })
                .GroupBy(x => new { x.MovieId, x.Title, x.Id, x.YearOfRelease, x.RunningTime, x.Genre })
                .Select(
                    e =>
                        new MovieDto
                        {
                            Id = e.Key.Id,
                            Title = e.Key.Title,
                            YearOfRelease = e.Key.YearOfRelease,
                            RunningTime = e.Key.RunningTime,
                            AverageRating = Math.Round(e.Average(i => (double)i.Rating), 1),
                            Genre = e.Key.Genre
                        }).ToList();
            return query;
        }
        private IEnumerable<MovieDto> GetMoviesWithUserRatings()
        {
            var query = _context.MovieRatings.Join(_context.Movies, r => r.MovieId, m => m.Id, (r, m) => new
            {
                r,
                m
            }).Join(_context.Users, ro => ro.r.UserId, u => u.Id, (ro, u) => new
            {
                ro.r.Rating,
                ro.r.MovieId,
                ro.m.Id,
                ro.m.Title,
                ro.m.YearOfRelease,
                ro.m.RunningTime,
                ro.m.Genre,
                ro.r.UserId
            })
                .GroupBy(x => new { x.UserId, x.MovieId, x.Title, x.Id, x.YearOfRelease, x.RunningTime, x.Genre, x.Rating })
                .Select(
                    e =>
                        new MovieDto
                        {
                            Id = e.Key.Id,
                            Title = e.Key.Title,
                            YearOfRelease = e.Key.YearOfRelease,
                            RunningTime = e.Key.RunningTime,
                            AverageRating = (double)e.Key.Rating,
                            Genre = e.Key.Genre,
                            UserId = e.Key.UserId
                        }).ToList();
            return query;
        }

        public List<MovieDto> GetTopMovies()
        {
            return GetMoviesWithRatings().OrderByDescending(r => r.AverageRating).ThenBy(r => r.Title).Take(5).ToList();

        }

        public List<MovieDto> GetMyTopMovies(int userId)
        {
            return GetMoviesWithUserRatings().Where(u => u.UserId == userId).OrderByDescending(r => r.AverageRating).ThenBy(r => r.Title).Take(5).ToList();
        }

        public bool PostMyRating(UserRatingDto rating)
        {
            if (_context.Users.Any(u => u.Id == rating.UserId) && _context.Movies.Any(m => m.Id == rating.MovieId))
            {
                try
                {
                    var ratingDetails = new MovieRating()
                    {
                        Rating = rating.Rating,
                        UserId = rating.UserId,
                        MovieId = rating.MovieId
                    };
                    var userRating =
                        _context.MovieRatings.SingleOrDefault(r => r.MovieId == rating.MovieId && r.UserId == rating.UserId);
                    if (userRating == null)
                    {
                        _context.MovieRatings.Add(ratingDetails);
                    }
                    else
                    {
                        userRating.Rating = rating.Rating;
                    }
                    _context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}