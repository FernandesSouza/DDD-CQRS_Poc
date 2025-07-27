using FluentValidation;
using DomainDrivenDesign_Poc.Business.Domain.Entities;

namespace DomainDrivenDesign_Poc.Business.Domain.EntitiesValidation;

public class StudentValidation : AbstractValidator<Student>
{
    public StudentValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(s => s.Email.Value)
            .MinimumLength(10)
            .WithMessage("Email inválido");

        RuleFor(s => s.FullName)
            .MinimumLength(2)
            .WithMessage("Name inválido");

        RuleFor(s => s.Document.Value)
            .MinimumLength(11)
            .WithMessage("Document inválido");
    }
}