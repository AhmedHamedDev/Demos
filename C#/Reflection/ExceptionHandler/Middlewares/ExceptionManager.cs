using ExceptionHandler.Exceptions.Contract;
using System.Collections.Concurrent;
using System.Net;

namespace ExceptionHandler.Middlewares
{
    public class ExceptionManager
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionManager> _logger;
        private readonly static ConcurrentDictionary<Type, IExceptionHandleBase> keyValuePairs = new ConcurrentDictionary<Type, IExceptionHandleBase>();

        public ExceptionManager(RequestDelegate next, ILogger<ExceptionManager> logger, IServiceProvider serviceProvider)
        {
            _next = next;
            _logger = logger;

            var AllConcreteAndInterfaces = typeof(ExceptionManager).Assembly.GetTypes()
                                           .Where(x => x.IsClass == true
                                           && x.GetInterfaces().Where(x => x.Name == "IExceptionManager`1").Count() > 0)
                                           .Select(x => new { contract = x.GetInterfaces()[0], errorType = x.GetInterfaces()[0].GetGenericArguments()[0] });

            foreach (var item in AllConcreteAndInterfaces)
            {
                var service = serviceProvider.GetService(item.contract);
                keyValuePairs.TryAdd(item.errorType, (IExceptionHandleBase)service);
            }
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exp)
            {
                await keyValuePairs[exp.GetType()].Handle(exp);
                _logger.LogError("{0}", exp);
            }

        }
    }
}
