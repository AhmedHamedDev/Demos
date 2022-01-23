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
            return services;
        }
    }

}
