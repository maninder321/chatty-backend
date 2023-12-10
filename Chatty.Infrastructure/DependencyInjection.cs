using Chatty.ApplicationCore.Interfaces.Repositories;
using Chatty.Infrastructure.Context;
using Chatty.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chatty.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration Configuration
    )
    {
        services.AddDbContext<ChattyDbContext>(options =>
        {
            options.UseMySQL(Configuration.GetConnectionString("ChattyDatabase")!);
        });

        services.AddScoped<IChattyBrowserSessionRepository, ChattyBrowserSessionRepository>();

        return services;
    }

}

