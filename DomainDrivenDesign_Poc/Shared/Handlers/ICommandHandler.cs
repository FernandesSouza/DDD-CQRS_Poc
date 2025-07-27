using DomainDrivenDesign_Poc.Shared.Result;

namespace DomainDrivenDesign_Poc.Shared.Handlers;

public interface ICommandHandler<in T> where T : class
{
    Task<CommandResult> HandleAsync(T command);
}