namespace DomainDrivenDesign_Poc.Shared.Handlers;

public interface IEventHandler<in T> where T : class
{
    Task HandleAsync(T domainEvent);
}