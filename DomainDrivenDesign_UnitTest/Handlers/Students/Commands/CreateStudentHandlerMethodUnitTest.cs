using System.Linq.Expressions;
using DomainDrivenDesign_Poc.Business.ApplicationService.Commands.StudentsCommands;
using DomainDrivenDesign_Poc.Business.Domain.Entities;
using DomainDrivenDesign_UnitTest.Handlers.Students.Commands.Setups;
using Moq;

namespace DomainDrivenDesign_UnitTest.Handlers.Students.Commands;

public sealed class CreateStudentHandlerMethodUnitTest : CreateCommandSetup
{
    [Fact]
    [Trait("Handler", "Create Student - Success")]
    public async Task Create_Student_Success()
    {
        var command = new CreateStudentCommand
        {
            Name = "João",
            Email = "joao@email.com",
            Document = "12345678901",
            Number = "1234 1234 1234 1234",
            Payer = "João",
        };

        StudentRepository
            .Setup(s => s.ExistAsync(
                It.IsAny<Expression<Func<Student, bool>>>()))
            .ReturnsAsync(false);
        StudentRepository
            .Setup(r => r.SaveAsync(
                It.IsAny<Student>()))
            .ReturnsAsync(true);

        var result = await CreateStudentHandler.HandleAsync(command);

        Assert.True(result.Success);

        StudentRepository
            .Verify(s => s.ExistAsync(
                It.IsAny<Expression<Func<Student, bool>>>()), Times.Once);
        StudentRepository
            .Verify(r => r.SaveAsync(
                It.IsAny<Student>()), Times.Once);
    }

    [Fact]
    [Trait("Handler", "Create Student - Failed")]
    public async Task Create_Student_Failed()
    {
        var command = new CreateStudentCommand
        {
            Name = "João",
            Email = "joao@email.com",
            Document = "12345678901",
            Number = "1234 1234 1234 1234",
            Payer = "João",
        };

        StudentRepository
            .Setup(s => s.ExistAsync(
                It.IsAny<Expression<Func<Student, bool>>>()))
            .ReturnsAsync(true);

        var result = await CreateStudentHandler.HandleAsync(command);

        Assert.False(result.Success);

        StudentRepository
            .Verify(s => s.ExistAsync(
                It.IsAny<Expression<Func<Student, bool>>>()), Times.Once);
        StudentRepository
            .Verify(r => r.SaveAsync(
                It.IsAny<Student>()), Times.Never);
    }
}