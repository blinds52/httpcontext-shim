using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Net.Http;

namespace HttpContextShim
{
    public class SelfHostHttpContext : IHttpContext
    {
        public DateTime Timestamp { get; private set; }
        public IHttpRequest Request { get; private set; }
        public IHttpResponse Response { get; private set; }
        public IDictionary Items { get; private set; }
        public SelfHostHttpContext()
        {
            Timestamp = DateTime.Now;
            Items = new ConcurrentDictionary<string, object>();
        }
        public SelfHostHttpContext(HttpRequestMessage request) : this()
        {
            Request = new SelfHostHttpRequest(request);
        }
        public void SetResponse(HttpResponseMessage response)
        {
            Response = new SelfHostHttpResponse(response);
        }
    }
}