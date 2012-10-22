using System;

namespace HttpContextShim
{
    public class SelfHostHttpContext : IHttpContext
    {
        public DateTime Timestamp { get; private set; }
        public IHttpRequest Request { get; private set; }
        public IHttpResponse Response { get; private set; }

        public SelfHostHttpContext()
        {
            
        }
    }
}