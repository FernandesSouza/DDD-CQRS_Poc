using DomainDrivenDesign_Poc.Business.Domain.Entities.Base;

namespace DomainDrivenDesign_Poc.Business.Domain.ValueObjects;

public sealed class Email(string value) : Entity
{
    public string Value { get; private set; } = value;
}