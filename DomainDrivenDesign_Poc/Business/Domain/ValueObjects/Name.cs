namespace DomainDrivenDesign_Poc.Business.Domain.ValueObjects;

public sealed class Name(string firstName, string lastName)
{
    public string FirstName { get; set; } = firstName;
    public string? LastName { get; set; } = lastName;
}