using System.Collections.Generic;
using System.Linq;

namespace Requests.Responses
{
    public class ErrorResponse
    {
        public Dictionary<string, string[]> Body { get; set; }

        public string Message => Body.First().Value[0];
    }
}
