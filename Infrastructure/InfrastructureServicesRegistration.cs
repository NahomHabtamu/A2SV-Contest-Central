using Application.Contracts.Infrastructure;
using Application.Contracts.Infrastructure.ExternalServices;
using Infrastructure.ExternalServices;
using Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddSingleton<IConfiguration>(configuration);
        services.AddScoped<ICodeforcesApiService, CodeforcesApiService>();
        services.Configure<CodeforcesAPISettings>(
            configuration.GetSection("CodeforcesAPISettings")
        );
        services.AddHttpClient();

        return services;
    }
}
