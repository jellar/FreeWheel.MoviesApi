using FreeWheel.MoviesApi.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FreeWheel.MoviesApi.Data
{
    public class DbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            LoadMoviesData(context);
        }

        private static void LoadMoviesData(ApplicationDbContext context)
        {
            var users = new List<User>
                {
                    new User {FirstName = "Rajesh", Surname = "Jella", UserName = "jellar"},
                    new User {FirstName = "Json", Surname = "Reed", UserName = "reedj"},
                    new User {FirstName = "Nick", Surname = "Reader", UserName = "readern"},
                    new User {FirstName = "Test_Firstname", Surname = "Test_Surname", UserName = "tester"}
                };
            if (!context.Users.Any())
            {
                foreach (var user in users)
                {
                    context.Users.AddOrUpdate(user);
                }
                context.SaveChanges();
            }

            var movies = new List<Movie>
                {
                    new Movie
                    {
                        Genre = "Action",
                        Title = "The Shawshank Redemption",
                        YearOfRelease = 1994,
                        RunningTime = 142
                    },
                    new Movie
                    {
                        Genre = "Romance",
                        Title = "Forrest Gump ",
                        YearOfRelease = 1994,
                        RunningTime = 142
                    },
                    new Movie
                    {
                        Genre = "Thriller",
                        Title = "Schindler's List",
                        YearOfRelease = 1993,
                        RunningTime = 195
                    },
                    new Movie
                    {
                        Genre = "Thriller",
                        Title = "The Godfather ",
                        YearOfRelease = 1972,
                        RunningTime = 175
                    },
                    new Movie
                    {
                        Genre = "Thriller",
                        Title = "The Green Mile ",
                        YearOfRelease = 1999,
                        RunningTime = 189
                    },
                    new Movie
                    {
                        Genre = "Family",
                        Title = "Hotel Rwanda",
                        YearOfRelease = 2004,
                        RunningTime = 121
                    },
                    new Movie
                    {
                        Genre = "Thriller",
                        Title = "Goodfellas",
                        YearOfRelease = 1990,
                        RunningTime = 146
                    },
                    new Movie
                    {
                        Genre = "Action",
                        Title = "3:10 to Yuma ",
                        YearOfRelease = 2007,
                        RunningTime = 122
                    },
                    new Movie 
                    {   
                        Genre = "Thriller", 
                        Title = "Scarface", 
                        YearOfRelease = 1983, 
                        RunningTime = 170
                    },
                    new Movie
                    {
                        Genre = "Comedy",
                        Title = "The Bucket List",
                        YearOfRelease = 2007,
                        RunningTime = 97
                    },
                    new Movie
                    {
                        Genre = "Comedy",
                        Title = "The Terminal",
                        YearOfRelease = 2004,
                        RunningTime = 128
                    },
                    new Movie
                    {
                        Genre = "Family",
                        Title = "Million Dollar Baby",
                        YearOfRelease = 2004,
                        RunningTime = 132
                    },
                    new Movie
                    {
                        Genre = "Comedy",
                        Title = "The Bridges of madison County",
                        YearOfRelease = 1995,
                        RunningTime = 135
                    },
                    new Movie
                    {
                        Genre = "Family",
                        Title = "Driving Miss Daisy",
                        YearOfRelease = 1989,
                        RunningTime = 99
                    },
                    new Movie
                    {
                        Genre = "Thriller",
                        Title = "Catch Me if You Can",
                        YearOfRelease = 2002,
                        RunningTime = 141
                    }
                };
            if (!context.Movies.Any())
            {
                foreach (var movie in movies)
                {
                    context.Movies.AddOrUpdate(movie);
                }
                context.SaveChanges();
            }

            if (!context.MovieRatings.Any())
            {
                var movieRatings = new List<MovieRating>
                {
                    new MovieRating {MovieId = movies[0].Id, Rating = Rating.FiveStar, UserId = users[0].Id},
                    new MovieRating {MovieId = movies[1].Id, Rating = Rating.ThreeStar, UserId = users[0].Id},
                    new MovieRating {MovieId = movies[2].Id, Rating = Rating.ThreeStar, UserId = users[0].Id},
                    new MovieRating {MovieId = movies[3].Id, Rating = Rating.FourStar, UserId = users[0].Id},
                    new MovieRating {MovieId = movies[4].Id, Rating = Rating.FourStar, UserId = users[0].Id},
                    new MovieRating {MovieId = movies[5].Id, Rating = Rating.TwoStar, UserId = users[0].Id},
                    new MovieRating {MovieId = movies[6].Id, Rating = Rating.ThreeStar, UserId = users[0].Id},
                    new MovieRating {MovieId = movies[7].Id, Rating = Rating.FiveStar, UserId = users[0].Id},
                    new MovieRating {MovieId = movies[8].Id, Rating = Rating.OneStar, UserId = users[0].Id},
                    new MovieRating {MovieId = movies[9].Id, Rating = Rating.FourStar, UserId = users[0].Id},
                    new MovieRating {MovieId = movies[10].Id, Rating = Rating.ThreeStar, UserId = users[0].Id},
                    new MovieRating {MovieId = movies[11].Id, Rating = Rating.TwoStar, UserId = users[0].Id},
                    new MovieRating {MovieId = movies[12].Id, Rating = Rating.FiveStar, UserId = users[0].Id},
                    new MovieRating {MovieId = movies[13].Id, Rating = Rating.FourStar, UserId = users[0].Id},
                    new MovieRating {MovieId = movies[14].Id, Rating = Rating.ThreeStar, UserId = users[0].Id},

                    new MovieRating {MovieId = movies[0].Id, Rating = Rating.FourStar, UserId = users[1].Id},
                    new MovieRating {MovieId = movies[1].Id, Rating = Rating.ThreeStar, UserId = users[1].Id},
                    new MovieRating {MovieId = movies[2].Id, Rating = Rating.FourStar, UserId = users[1].Id},
                    new MovieRating {MovieId = movies[3].Id, Rating = Rating.FourStar, UserId = users[1].Id},
                    new MovieRating {MovieId = movies[4].Id, Rating = Rating.FourStar, UserId = users[1].Id},
                    new MovieRating {MovieId = movies[5].Id, Rating = Rating.TwoStar, UserId = users[1].Id},
                    new MovieRating {MovieId = movies[6].Id, Rating = Rating.ThreeStar, UserId = users[1].Id},
                    new MovieRating {MovieId = movies[7].Id, Rating = Rating.FourStar, UserId = users[1].Id},
                    new MovieRating {MovieId = movies[8].Id, Rating = Rating.OneStar, UserId = users[1].Id},
                    new MovieRating {MovieId = movies[9].Id, Rating = Rating.FourStar, UserId = users[1].Id},
                    new MovieRating {MovieId = movies[10].Id, Rating = Rating.ThreeStar, UserId = users[1].Id},
                    new MovieRating {MovieId = movies[11].Id, Rating = Rating.ThreeStar, UserId = users[1].Id},
                    new MovieRating {MovieId = movies[12].Id, Rating = Rating.FiveStar, UserId = users[1].Id},
                    new MovieRating {MovieId = movies[13].Id, Rating = Rating.FourStar, UserId = users[1].Id},
                    new MovieRating {MovieId = movies[14].Id, Rating = Rating.FourStar, UserId = users[1].Id},

                    new MovieRating {MovieId = movies[0].Id, Rating = Rating.FourStar, UserId = users[2].Id},
                    new MovieRating {MovieId = movies[1].Id, Rating = Rating.ThreeStar, UserId = users[2].Id},
                    new MovieRating {MovieId = movies[2].Id, Rating = Rating.FourStar, UserId = users[2].Id},
                    new MovieRating {MovieId = movies[3].Id, Rating = Rating.FiveStar, UserId = users[2].Id},
                    new MovieRating {MovieId = movies[4].Id, Rating = Rating.ThreeStar, UserId = users[2].Id},
                    new MovieRating {MovieId = movies[5].Id, Rating = Rating.ThreeStar, UserId = users[2].Id},
                    new MovieRating {MovieId = movies[6].Id, Rating = Rating.ThreeStar, UserId = users[2].Id},
                    new MovieRating {MovieId = movies[7].Id, Rating = Rating.FourStar, UserId = users[2].Id},
                    new MovieRating {MovieId = movies[8].Id, Rating = Rating.ThreeStar, UserId = users[2].Id},
                    new MovieRating {MovieId = movies[9].Id, Rating = Rating.FourStar, UserId = users[2].Id},
                    new MovieRating {MovieId = movies[10].Id, Rating = Rating.ThreeStar, UserId = users[2].Id},
                    new MovieRating {MovieId = movies[11].Id, Rating = Rating.ThreeStar, UserId = users[2].Id},
                    new MovieRating {MovieId = movies[12].Id, Rating = Rating.FourStar, UserId = users[2].Id},
                    new MovieRating {MovieId = movies[13].Id, Rating = Rating.FourStar, UserId = users[2].Id},
                    new MovieRating {MovieId = movies[14].Id, Rating = Rating.FourStar, UserId = users[2].Id}
                   
                };
                foreach (var movieRating in movieRatings)
                {
                    context.MovieRatings.AddOrUpdate(movieRating);
                }

            }


            context.SaveChanges();
        }
    }
}