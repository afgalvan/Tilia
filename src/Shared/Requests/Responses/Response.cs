namespace Requests.Responses
{
    public abstract class Response<TContent>
    {
        public string   Message { get; set; }
        public bool     IsError { get; set; }

        protected Response(string message)
        {
            Message = message;
        }

        protected Response()
        {
        }
    }
}
