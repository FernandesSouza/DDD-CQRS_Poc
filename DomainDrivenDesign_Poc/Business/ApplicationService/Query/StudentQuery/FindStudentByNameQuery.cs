namespace DomainDrivenDesign_Poc.Business.ApplicationService.Query.StudentQuery;

public sealed record FindStudentByNameQuery
{
    public required string Name { get; set; }
}