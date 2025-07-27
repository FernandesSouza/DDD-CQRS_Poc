using DomainDrivenDesign_Poc.Business.ApplicationService.Services.Interfaces;
using DomainDrivenDesign_Poc.Business.Domain.DomainEvents;
using DomainDrivenDesign_Poc.Business.Domain.DomainEvents.Base;

namespace DomainDrivenDesign_Poc.Business.ApplicationService.Services;

public sealed class EmailService : IEmailService, IDisposable
{
    //Simula envio de email
    public EmailService()
    {
        DomainEvent<StudentRegisterEvent>.OnEventDomain += SendEmailAsync;
    }

    public void SendEmailAsync(StudentRegisterEvent studentRegisterEvent)
    {
        Console.WriteLine($"Sending email to {studentRegisterEvent.Email.Value}" +
                          $"\n Congratulations{studentRegisterEvent.FullName} you are registered!");
    }

    public void Dispose()
    {
        DomainEvent<StudentRegisterEvent>.OnEventDomain -= SendEmailAsync;
        GC.SuppressFinalize(this);
    }
}