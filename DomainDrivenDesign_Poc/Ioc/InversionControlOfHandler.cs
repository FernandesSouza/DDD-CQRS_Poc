using DomainDrivenDesign_Poc.Infraestrutura.ORM.Context;
using DomainDrivenDesign_Poc.Ioc.Container;

namespace DomainDrivenDesign_Poc.Ioc;

public static class InversionControlOfHandler
{
    public static void AddInversionControlOfHandler(this IServiceCollection service) =>
        service
            .AddScoped<ApplicationContext>()
            .AddRepository()
            .AddHandler();
}