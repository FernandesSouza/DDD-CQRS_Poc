using DomainDrivenDesign_Poc.Business.ApplicationService.Commands.StudentsCommands;
using DomainDrivenDesign_Poc.Business.ApplicationService.DTOs;
using DomainDrivenDesign_Poc.Business.ApplicationService.Query.StudentQuery;
using DomainDrivenDesign_Poc.Business.ApplicationService.Services;
using DomainDrivenDesign_Poc.Business.ApplicationService.Services.Interfaces;
using DomainDrivenDesign_Poc.Business.ApplicationService.StudentHandler;
using DomainDrivenDesign_Poc.Shared.Handlers;

namespace DomainDrivenDesign_Poc.Ioc.Container;

public static class HandlerContainer
{
    public static void AddHandler(this IServiceCollection service) =>
        service.AddScoped<ICommandHandler<CreateStudentCommand>, CreateStudentHandler>()
            .AddScoped<IQueryHandler<FindStudentByNameQuery, StudentResponseByName>, FindStudentByNameHandler>()
            .AddScoped<IEmailService, EmailService>();
}