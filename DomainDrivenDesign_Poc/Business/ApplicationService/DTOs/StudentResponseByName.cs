using DomainDrivenDesign_Poc.Business.Domain.ValueObjects;

namespace DomainDrivenDesign_Poc.Business.ApplicationService.DTOs;

public sealed record StudentResponseByName
{
    public string? Name { get; set; }
    public Email? Email { get; init; }
    public Document? Document { get; init; }
}