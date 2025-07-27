namespace DomainDrivenDesign_Poc.Business.ApplicationService.Commands.StudentsCommands;

public sealed record CreateStudentCommand
{
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Document { get; init; }

    public required string Number { get; set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public required string Payer { get; set; }
}