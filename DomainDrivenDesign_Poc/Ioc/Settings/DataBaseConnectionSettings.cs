using Microsoft.EntityFrameworkCore;
using DomainDrivenDesign_Poc.Infraestrutura.ORM.Context;
using DomainDrivenDesign_Poc.Shared.Providers;

namespace DomainDrivenDesign_Poc.Ioc.Settings;

public static class DataBaseConnectionSettings
{
    public static void AddDataBaseConnectionSettings(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationContext>((serviceProv, options) =>
            options.UseSqlServer(
                serviceProv.GetRequiredService<ConnectionStringOptions>().DefaultConnection,
                sql => sql.CommandTimeout(180)));
    }
}