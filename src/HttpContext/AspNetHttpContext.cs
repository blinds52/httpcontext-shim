using System;
using System.Web;

namespace HttpContextShim
{
    public interface IHttpRequest
    {
        
    }

    public class AspNetHttpRequest : IHttpRequest
    {
        public AspNetHttpRequest(HttpRequest request)
        {
            
        }

        public AspNetHttpRequest(HttpRequestBase request)
        {
            
        }
    }

    public interface IHttpResponse
    {
        
    }

    public class AspNetHttpResponse : IHttpResponse
    {
        public AspNetHttpResponse(HttpResponse response)
        {
            
        }

        public AspNetHttpResponse(HttpResponseBase response)
        {
            
        }
    }

    public interface IHttpContext
    {
        DateTime Timestamp { get; }
        IHttpRequest Request { get; }
        IHttpResponse Response { get; }
    }

    public class AspNetHttpContext : IHttpContext
    {

        public AspNetHttpContext(System.Web.HttpContext context)
        {
            Timestamp = context.Timestamp;
            Request = new AspNetHttpRequest(context.Request);
            Response = new AspNetHttpResponse(context.Response);
        }

        public AspNetHttpContext(HttpContextBase context)
        {
            Timestamp = context.Timestamp;
            Request = new AspNetHttpRequest(context.Request);
            Response = new AspNetHttpResponse(context.Response);
        }

        public DateTime Timestamp { get; private set;  }
        public IHttpRequest Request { get; private set; }
        public IHttpResponse Response { get; private set; }
    }
}