namespace Requests.Responses
{
    public class OkResponse<TContent> : Response<TContent>
    {
        public TContent Content { get; set; }

        public OkResponse(string message, TContent content) : base(message)
        {
            Content = content;
            IsError = false;
        }

        public OkResponse(string message) : base(message)
        {
            IsError = false;
        }

        public OkResponse(TContent content) : this("", content)
        {
        }
    }
}
