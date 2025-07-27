using DomainDrivenDesign_Poc.Business.ApplicationService.StudentHandler;
using DomainDrivenDesign_Poc.Infraestrutura.Interface;
using Moq;

namespace DomainDrivenDesign_UnitTest.Handlers.Students.Commands.Setups;

public abstract class CreateCommandSetup
{
    protected CreateStudentHandler CreateStudentHandler;
    protected readonly Mock<IStudentRepository> StudentRepository;

    protected CreateCommandSetup()
    {
        StudentRepository = new Mock<IStudentRepository>();
        CreateStudentHandler = new CreateStudentHandler(
            StudentRepository.Object);
    }
}