using System;
using System.Collections;

namespace HttpContextShim
{
    public interface IHttpContext
    {
        DateTime Timestamp { get; }
        IHttpRequest Request { get; }
        IHttpResponse Response { get; }
        IDictionary Items { get; }
        object Inner { get; }
    }
}