using System;

namespace Presentation.Services.Http.Utils
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
