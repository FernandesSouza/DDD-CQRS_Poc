using DomainDrivenDesign_Poc.Business.Domain.DomainEvents;

namespace DomainDrivenDesign_Poc.Business.ApplicationService.Services.Interfaces;

public interface IEmailService
{
    public void SendEmailAsync(StudentRegisterEvent studentRegisterEvent);
}