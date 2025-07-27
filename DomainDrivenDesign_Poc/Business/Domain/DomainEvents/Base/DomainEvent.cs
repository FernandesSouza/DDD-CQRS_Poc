namespace DomainDrivenDesign_Poc.Business.Domain.DomainEvents.Base;

public static class DomainEvent<T>
{
    public static event Action<T>? OnEventDomain;

    public static void Handler(T domainEvent)
    {
        OnEventDomain?.Invoke(domainEvent);
    }
}