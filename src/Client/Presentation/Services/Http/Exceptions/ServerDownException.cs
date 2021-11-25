using System;

namespace Presentation.Services.Http.Exceptions
{
    public class ServerDownException : Exception
    {
        public ServerDownException(string message) : base(message)
        {
        }

        public ServerDownException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
