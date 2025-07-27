using DomainDrivenDesign_Poc.Infraestrutura.Interface;
using DomainDrivenDesign_Poc.Infraestrutura.Repository;

namespace DomainDrivenDesign_Poc.Ioc.Container;

public static class RepositoryContainer
{
    public static IServiceCollection AddRepository(this IServiceCollection service) =>
        service.AddScoped<IStudentRepository, StudentRepository>();
}