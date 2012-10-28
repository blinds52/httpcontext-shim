using System;
using System.Collections;
using System.Threading;

namespace HttpContextShim
{
    public class HttpContext : IHttpContext
    {
        private static readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();
        private static volatile IHttpContext _current;
        public static IHttpContext Current
        {
            get
            {
                try
                {
                    Lock.EnterReadLock();
                    return _current;
                }
                finally
                {
                    Lock.ExitReadLock();
                }
            }
            set
            {
                try
                {
                    Lock.EnterWriteLock();
                    _current = value;
                }
                finally
                {
                    Lock.ExitWriteLock();                    
                }
            }
        }

        public DateTime Timestamp { get { return Current.Timestamp; } }
        public IHttpRequest Request { get { return Current.Request; } }
        public IHttpResponse Response { get { return Current.Response; }}
        public IDictionary Items { get { return Current.Items; } }
        public object Inner { get { return Current.Inner; } }
    }
}