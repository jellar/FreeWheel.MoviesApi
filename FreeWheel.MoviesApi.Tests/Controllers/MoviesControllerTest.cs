
using FreeWheel.MoviesApi.Dtos;
using FreeWheel.MoviesApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace FreeWheel.MoviesApi.Tests.Controllers
{
    [TestClass]
    public class MoviesControllerTest : BaseController
    {
        [TestMethod]
        public void MoviesWithInvalid()
        {
            var client = new HttpClient();
            var request = CreateRequest("api/movies", "application/json", HttpMethod.Get);
            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [TestMethod]
        public void MoviesNotFound()
        {
            var client = new HttpClient();
            var request = CreateRequest("api/movies?year=0001", "application/json", HttpMethod.Get);
            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            }
        }

        [TestMethod]
        public void MoviesWithMultipleGenre()
        {
            var client = new HttpClient();
            var request = CreateRequest("api/movies?genre=comedy,thriller", "application/json", HttpMethod.Get);
            using (var response = client.SendAsync(request).Result)
            {
                var result = response.Content.ReadAsAsync<List<MovieDto>>().Result;
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [TestMethod]
        public void TopMovies()
        {
            var client = new HttpClient();
            var request = CreateRequest("api/movies/top", "application/json", HttpMethod.Get);
            using (var response = client.SendAsync(request).Result)
            {
                var result = response.Content.ReadAsAsync<List<MovieDto>>().Result;
                Assert.AreEqual(5, result.Count);
            }
        }

        [TestMethod]
        public void PostRating()
        {
            var client = new HttpClient();
            var postAddress = string.Format("api/movies/rating");

            client.BaseAddress = new Uri(Url);
            //string myJson = "{'userId': 4,'movieId':2, 'Rating':4}";
            var data = new UserRatingDto() { UserId = 4, MovieId = 2, Rating = Rating.FourStar }; // <---- Note that this is an explicit object, not an interface
            var postData = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var response = client.PostAsync(postAddress, postData).Result)
            {
                var result = response.Content.ReadAsAsync<UserRatingDto>().Result;
                Assert.AreEqual(4, result.UserId);
                Assert.AreEqual(2, result.MovieId);
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            }
        }
    }
}
