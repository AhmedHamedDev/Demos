using System.Net;

namespace ExceptionHandler.Middlewares
{
    public class ExceptionManager
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionManager> _logger;

        public ExceptionManager(RequestDelegate next, ILogger<ExceptionManager> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exp)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError("{0}", exp);
            }

        }
    }
}
