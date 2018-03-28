using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;

namespace FreeWheel.MoviesApi.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest : BaseController
    {
        [TestMethod]
        public void GetMyTopMovies()
        {
            var client = new HttpClient();
            var request = CreateRequest("api/1/my-top-movies", "application/json", HttpMethod.Get);
            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

    }
}
