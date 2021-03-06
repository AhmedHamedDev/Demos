using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

namespace CoreChannels.Services
{
    public class NotificationDispatcher : BackgroundService
    {
        private readonly Channel<string> channel;
        private readonly ILogger<NotificationDispatcher> logger;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IServiceProvider provider;

        public NotificationDispatcher(
            Channel<string> channel,
            ILogger<NotificationDispatcher> logger,
            IHttpClientFactory httpClientFactory,
            IServiceProvider provider)
        {
            this.channel = channel;
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
            this.provider = provider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!channel.Reader.Completion.IsCompleted) // if not complete
            {
                // read from channel
                var msg = await channel.Reader.ReadAsync();
                try
                {
                    using (var scope = provider.CreateScope())
                    {
                        var database = scope.ServiceProvider.GetRequiredService<Database>();
                        if (!await database.Users.AnyAsync())
                        {
                            database.Users.Add(new User() { Id=1, Message = "test" });
                            await database.SaveChangesAsync();
                        }

                        var user = await database.Users.FirstOrDefaultAsync();

                        var client = httpClientFactory.CreateClient();
                        var response = await client.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/core/");
                        user.Message = response;

                        await database.SaveChangesAsync();
                    }
                }
                catch (Exception e)
                {
                    logger.LogError(e, "notification failed");
                }
            }
        }
    }
}
