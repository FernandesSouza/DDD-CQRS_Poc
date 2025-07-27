using Microsoft.Extensions.Options;
using DomainDrivenDesign_Poc.Shared.Providers;

namespace DomainDrivenDesign_Poc.Ioc.Settings;

public static class ProviderSettings
{
    public static void AddProviderSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(sp => sp.GetService<IOptionsMonitor<ConnectionStringOptions>>()!.CurrentValue);
        services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));
    }
}