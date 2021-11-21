namespace Requests.Responses
{
    public class ErrorResponse<TContent> : Response<TContent>
    {
        public ErrorResponse(string message) : base(message)
        {
            IsError = true;
        }

        public ErrorResponse() : this("")
        {
        }
    }
}
