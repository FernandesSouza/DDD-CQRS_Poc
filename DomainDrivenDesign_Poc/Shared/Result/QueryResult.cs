namespace DomainDrivenDesign_Poc.Shared.Result;

public class QueryResult<T>(
    bool success,
    List<T>? allItems = null,
    T? item = default)
{

    public bool Success { get; set; } = success;
    public List<T>? AllItems { get; set; } = allItems;
    public T? Item { get; set; } = item;
}