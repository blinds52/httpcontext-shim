using System;
using System.Collections;
using System.Web;

namespace HttpContextShim
{
    public class AspNetHttpContext : IHttpContext
    {
        public AspNetHttpContext(System.Web.HttpContext context)
        {
            Timestamp = context.Timestamp;
            Request = new AspNetHttpRequest(context.Request);
            Response = new AspNetHttpResponse(context.Response);
            Items = context.Items;
        }

        public AspNetHttpContext(HttpContextBase context)
        {
            Timestamp = context.Timestamp;
            Request = new AspNetHttpRequest(context.Request);
            Response = new AspNetHttpResponse(context.Response);
            Items = context.Items;
        }

        public DateTime Timestamp { get; private set;  }
        public IHttpRequest Request { get; private set; }
        public IHttpResponse Response { get; set; }
        public IDictionary Items { get; private set; }
    }
}