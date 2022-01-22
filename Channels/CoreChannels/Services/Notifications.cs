﻿using Microsoft.EntityFrameworkCore;

namespace CoreChannels.Services
{
    public class Notifications
    {
        private readonly Database database;
        private readonly IHttpClientFactory httpClientFactory;

        public Notifications(Database database, IHttpClientFactory httpClientFactory)
        {
            this.database = database;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<bool> Send()
        {
            if (!await database.Users.AnyAsync())
            {
                database.Users.Add(new User());
                await database.SaveChangesAsync();
            }

            var user = await database.Users.FirstOrDefaultAsync();

            var client = httpClientFactory.CreateClient();
            var response = await client.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/core/");
            user.Message = response;

            await database.SaveChangesAsync();

            return true;
        }

        public bool SendA()
        {
            Task.Run(async () =>
            {
                try
                {
                    if (!await database.Users.AnyAsync())
                    {
                        database.Users.Add(new User());
                        await database.SaveChangesAsync();
                    }

                    var user = await database.Users.FirstOrDefaultAsync();

                    var client = httpClientFactory.CreateClient();
                    var response = await client.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/core/");
                    user.Message = response;

                    await database.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    var a = e;
                }
            });

            return true;
        }
    }
}
