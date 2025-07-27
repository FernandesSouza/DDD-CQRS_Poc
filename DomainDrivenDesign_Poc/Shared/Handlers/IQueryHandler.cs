using DomainDrivenDesign_Poc.Shared.Result;

namespace DomainDrivenDesign_Poc.Shared.Handlers;

public interface IQueryHandler<in TQuery, TResult>
{
    Task<QueryResult<TResult>> HandleAsync(TQuery query);
}