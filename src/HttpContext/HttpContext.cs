using System;
using System.Collections;
using System.Security.Principal;
using System.Threading;

namespace HttpContextShim
{
    public abstract class HttpContext : IHttpContext
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

        public DateTime Timestamp { get; protected set; }
        public IHttpRequest Request { get; protected set; }
        public IHttpResponse Response { get; protected set; }
        public IDictionary Items { get; protected set; }
        public IPrincipal User { get; protected set; }
        public object Inner { get; protected set; }
    }
}