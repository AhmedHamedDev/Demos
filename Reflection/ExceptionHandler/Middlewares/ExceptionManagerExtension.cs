namespace ExceptionHandler.Middlewares
{
    public static class ExceptionManagerrExtension
    {
        public static IApplicationBuilder UseExceptionManager(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionManager>();
            return app;
        }

        public static IServiceCollection AddExceptionManager(this IServiceCollection services)
        {
            var AllConcreteAndInterfaces = typeof(ExceptionManagerrExtension).Assembly.GetTypes()
                                                .Where(x => x.IsClass == true 
                                                && x.GetInterfaces().Where(x => x.Name == "IExceptionManager`1").Count() > 0)
                                                .Select(x => new { concrete = x, contract = x.GetInterfaces()[0] });
                                                
            foreach (var item in AllConcreteAndInterfaces)
                services.AddSingleton(item.contract, item.concrete);

            return services;
        }
    }

}
