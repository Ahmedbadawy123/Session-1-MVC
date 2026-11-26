using System.Diagnostics;

namespace MVCDemo01.Middlewares
{
    // To Make a Custom Middleware We Have Some Rules :
    /*
    1- RequestDelegate next [Inject Constructor]
    2- Method name InvokeAsync OR Invoke [HttpContext Parameter]
    3- Call await next(context).
    4- Register With app.UseMiddleware<RequestTimingMiddleWare>() 
     */

    public class RequestTimingMiddleWare
    {
        private readonly RequestDelegate _next;

        public RequestTimingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var Watch = Stopwatch.StartNew(); // Request
            await _next(context); // Call The Next Middleware in the Pipeline.
            Watch.Stop(); // Response
            Console.WriteLine($"{context.Request.Path} ==> {Watch.ElapsedMilliseconds} ms");
        }

    }
}
