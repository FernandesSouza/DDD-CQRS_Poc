using DomainDrivenDesign_Poc.Business.ApplicationService.Commands.StudentsCommands;
using DomainDrivenDesign_Poc.Business.ApplicationService.StudentHandler.Base;
using DomainDrivenDesign_Poc.Business.Domain.Entities;
using DomainDrivenDesign_Poc.Business.Domain.Enums;
using DomainDrivenDesign_Poc.Business.Domain.ValueObjects;
using DomainDrivenDesign_Poc.Infraestrutura.Interface;
using DomainDrivenDesign_Poc.Shared.Handlers;
using DomainDrivenDesign_Poc.Shared.Result;

namespace DomainDrivenDesign_Poc.Business.ApplicationService.StudentHandler;

public sealed class CreateStudentHandler(
    IStudentRepository studentRepository
) : BaseHandler, ICommandHandler<CreateStudentCommand>
{
    public async Task<CommandResult> HandleAsync(CreateStudentCommand command)
    {
        if (await CheckEmailAsync(command.Email))
            return new CommandResult(false, "Email já cadastrado");

        var student = CreateStudentFromValueObjects(command);

        student.CreateSubscriptionWithPayment(
            typeSubscription: ETypeSubscription.Annual,
            paymentNumber: command.Number,
            paymentTotal: command.Total,
            paymentTotalPaid: command.TotalPaid,
            paymentPayer: command.Payer
        );

        if (!student.IsValid)
            return CreateErrorsCommand(student.GetErrors!);

        var repositoryResult = await studentRepository.SaveAsync(student);

        return !repositoryResult
            ? new CommandResult(false, "Houve um problema com seu cadastro !")
            : new CommandResult(true, "Acesso a plataforma liberado");
    }

    private async Task<bool> CheckEmailAsync(string email) =>
        await studentRepository.ExistAsync(s => s.Email.Value == email);

    private Student CreateStudentFromValueObjects(CreateStudentCommand command)
    {
        var email = new Email(command.Email);
        var document = new Document(command.Document);
        return new Student(command.Name, email, document);
    }
}