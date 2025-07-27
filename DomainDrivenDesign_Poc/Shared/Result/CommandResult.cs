namespace DomainDrivenDesign_Poc.Shared.Result;

public class CommandResult(bool success, string? message)
{
    public bool Success { get; set; } = success;
    public string? Message { get; set; } = message;
}