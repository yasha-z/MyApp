using System.Diagnostics; //for stopwatch

namespace Session1
{
    // TASK 2.4 — Add RequestLoggingMiddleware (logs method, path, status, elapsed ms)
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;


//this constructor provides these objects through dependency Injection
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;// pass the request to the next middleware in the pipeline or the controller
            _logger = logger; //used for writing messages to the console/logs.
        }
//this method is called for each incoming HTTP request. 
// it logs the request details, invokes the next middleware, 
// and logs the response details along with the elapsed time.
        public async Task InvokeAsync(HttpContext context) //conetxt has all the details about the request and response
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context); //it goes to the controller and executes the controller method and then comes back to this middleware

            stopwatch.Stop();

            _logger.LogInformation(
                "{Method} {Path} responded {StatusCode} in {ElapsedMs}ms",
                context.Request.Method, //eg get/post/put/delete
                context.Request.Path, //eg /api/books
                context.Response.StatusCode, //eg 200/404/500
                stopwatch.ElapsedMilliseconds); //eg 10ms
        }
    }
}
