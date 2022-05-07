using ITPack.Application.Services;
using ITPack.Domain.Reposatories;
using ITPack.Infrastructure.EF.Contexts;
using ITPack.Infrastructure.EF.Options;
using ITPack.Infrastructure.EF.Repositories;
using ITPack.Infrastructure.EF.Services;
using ITPack.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPackingListRepository, SqlServerPackingListRepository>();
            services.AddScoped<IPackingListReadService, SqlServerPackingListReadService>();

            var options = configuration.GetOptions<SqlServerOptions>("SqlServer");
            services.AddDbContext<ReadDbContext>(x => x.UseSqlServer(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(x => x.UseSqlServer(options.ConnectionString));

            return services;
        }
    }
}
