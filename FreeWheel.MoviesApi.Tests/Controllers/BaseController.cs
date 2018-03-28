using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FreeWheel.MoviesApi.Tests.Controllers
{
    public abstract class BaseController
    {
        protected const string Url = "http://localhost:50050/";


        protected HttpRequestMessage CreateRequest(string url, string mthv, HttpMethod method)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(Url + url)
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mthv));
            request.Method = method;

            return request;
        }
    }
}
