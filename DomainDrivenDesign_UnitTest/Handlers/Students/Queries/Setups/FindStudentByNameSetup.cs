using DomainDrivenDesign_Poc.Business.ApplicationService.StudentHandler;
using DomainDrivenDesign_Poc.Infraestrutura.Interface;
using Moq;

namespace DomainDrivenDesign_UnitTest.Handlers.Students.Queries.Setups;

public abstract class FindStudentByNameSetup
{
    protected readonly Mock<IStudentRepository> StudentRepository;
    protected readonly FindStudentByNameHandler FindStudentByNameHandler;

    protected FindStudentByNameSetup()
    {
        StudentRepository = new Mock<IStudentRepository>();
        FindStudentByNameHandler = new FindStudentByNameHandler(
            StudentRepository.Object);
    }
}