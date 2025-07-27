using System.Linq.Expressions;
using DomainDrivenDesign_Poc.Business.ApplicationService.Query.StudentQuery;
using DomainDrivenDesign_Poc.Business.Domain.Entities;
using DomainDrivenDesign_Poc.Business.Domain.ValueObjects;
using DomainDrivenDesign_UnitTest.Handlers.Students.Queries.Setups;
using Moq;

namespace DomainDrivenDesign_UnitTest.Handlers.Students.Queries;

public sealed class FindStudentByNameMethodUnitTest : FindStudentByNameSetup
{
    [Fact]
    [Trait("Handler", "Find Student By Name - Success")]
    public async Task Find_Student_By_Name_Success()
    {
        var student = new Student(
            "João",
            new Email("joao@email.com"),
            new Document("12345678901"));

        var query = new FindStudentByNameQuery
        {
            Name = "João"
        };

        StudentRepository
            .Setup(s => s.FindByPredicateAsync(
                It.IsAny<Expression<Func<Student, bool>>>()))
            .ReturnsAsync(student);

        var result = await FindStudentByNameHandler.HandleAsync(query);

        Assert.True(result.Success);
        Assert.Equal("João", result.Item!.Name);

        StudentRepository
            .Verify(s => s.FindByPredicateAsync(
                It.IsAny<Expression<Func<Student, bool>>>()), Times.Once);
    }
}