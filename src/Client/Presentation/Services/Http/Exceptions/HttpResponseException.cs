using System;
using System.Net;

namespace Presentation.Services.Http.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpResponseException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}
