using DomainDrivenDesign_Poc.Business.Domain.ValueObjects;

namespace DomainDrivenDesign_Poc.Business.Domain.DomainEvents;

public sealed class StudentRegisterEvent(
    string fullName,
    Email email)
{
    public string FullName { get; init; } = fullName;
    public Email Email { get; init; } = email;
}