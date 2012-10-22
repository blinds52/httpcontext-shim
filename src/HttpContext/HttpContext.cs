namespace HttpContextShim
{
    public class HttpContext
    {
        public static IHttpContext Current { get; internal set; }
    }
}