using FluentValidation;
using FluentValidation.Results;

namespace DomainDrivenDesign_Poc.Business.Domain.Entities.Base;

public abstract class Entity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    private ValidationResult? Validation { get; set; }

    public Dictionary<string, string>? GetErrors => Validation?.Errors.ToDictionary(
        error => error.PropertyName,
        error => error.ErrorMessage);

    public bool IsValid => GetErrors?.Count == 0;

    protected bool EntityValidation<TEntity>(TEntity entity, AbstractValidator<TEntity> validator)
    {
        Validation = validator.Validate(entity);

        return IsValid;
    }
}