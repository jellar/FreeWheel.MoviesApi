using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace FreeWheel.MoviesApi
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exceptionMessage = actionExecutedContext.Exception.InnerException == null ?
                                actionExecutedContext.Exception.Message : actionExecutedContext.Exception.InnerException.Message;
            //We can log this exception message to the database
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An unhandled exception was thrown by service." + exceptionMessage),
                ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
            };
            actionExecutedContext.Response = response;
        }
    }
}