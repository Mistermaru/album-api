using Album.Api.Models;
using System.Net;

namespace Album.Api
{
    public class GreetingService
    {
        public Response Greet(string name)
        {
            Response res = new Response();

            if (string.IsNullOrWhiteSpace(name))
            {
                res.ResponseContent = "Hello World";
            }
            else
            {
                res.ResponseContent = $"Hello {name} from {Dns.GetHostName()} v2";
            }

            return res;
        }
    }
}
