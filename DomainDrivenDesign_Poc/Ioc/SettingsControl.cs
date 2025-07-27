using DomainDrivenDesign_Poc.Ioc.Settings;

namespace DomainDrivenDesign_Poc.Ioc;

public static class SettingsControl
{
    public static void AddSettingsControl(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddProviderSettings(configuration);
        service.AddDataBaseConnectionSettings();
    }
}