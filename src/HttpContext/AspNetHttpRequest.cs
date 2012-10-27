using System.Web;

namespace HttpContextShim
{
    public class AspNetHttpRequest : IHttpRequest
    {
        public AspNetHttpRequest(HttpRequest request)
        {
            IsLocal = request.IsLocal;
            UserHostAddress = request.UserHostAddress;
        }

        public AspNetHttpRequest(HttpRequestBase request)
        {
            IsLocal = request.IsLocal;
        }

        public bool IsLocal { get; private set; }
        public string UserHostAddress { get; private set; }
    }
}