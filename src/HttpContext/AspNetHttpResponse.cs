using System.Web;

namespace HttpContextShim
{
    public class AspNetHttpResponse : IHttpResponse
    {
        public AspNetHttpResponse(HttpResponse response)
        {
            
        }

        public AspNetHttpResponse(HttpResponseBase response)
        {
            
        }
    }
}