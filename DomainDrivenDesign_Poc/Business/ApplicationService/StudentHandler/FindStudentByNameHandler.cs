using DomainDrivenDesign_Poc.Business.ApplicationService.DTOs;
using DomainDrivenDesign_Poc.Business.ApplicationService.Query.StudentQuery;
using DomainDrivenDesign_Poc.Infraestrutura.Interface;
using DomainDrivenDesign_Poc.Shared.Handlers;
using DomainDrivenDesign_Poc.Shared.Result;

namespace DomainDrivenDesign_Poc.Business.ApplicationService.StudentHandler;

public sealed class FindStudentByNameHandler(
    IStudentRepository studentRepository
) : IQueryHandler<FindStudentByNameQuery, StudentResponseByName>
{

    public async Task<QueryResult<StudentResponseByName>> HandleAsync(
        FindStudentByNameQuery query)
    {
        var student = await studentRepository.FindByPredicateAsync(
            s => s.FullName == query.Name);

        if (student is null)
            return new QueryResult<StudentResponseByName>(
                false, new List<StudentResponseByName>());

        return new QueryResult<StudentResponseByName>(
            true,
            null,
            new StudentResponseByName
            {
                Name = student.FullName,
                Document = student.Document,
                Email = student.Email
            });
    }
}