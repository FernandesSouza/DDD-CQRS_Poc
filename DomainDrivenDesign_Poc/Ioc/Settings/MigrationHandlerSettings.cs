using Microsoft.EntityFrameworkCore;
using DomainDrivenDesign_Poc.Infraestrutura.ORM.Context;

namespace DomainDrivenDesign_Poc.Ioc.Settings;

public static class MigrationHandlerSettings
{
    public static async Task MigrateDatabaseAsync(this WebApplication webApp)
    {
        using var scope = webApp.Services.CreateScope();
        await using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        await appContext.Database.MigrateAsync();
    }
}