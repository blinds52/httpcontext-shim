using System.Net.Http;

namespace HttpContextShim
{
    public class SelfHostHttpResponse : IHttpResponse
    {
        public SelfHostHttpResponse(HttpResponseMessage response)
        {
            
        }
    }
}