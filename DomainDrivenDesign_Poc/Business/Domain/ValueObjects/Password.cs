namespace DomainDrivenDesign_Poc.Business.Domain.ValueObjects;

public sealed class Password(string password)
{
    public string Value { get; set; } = password;
}