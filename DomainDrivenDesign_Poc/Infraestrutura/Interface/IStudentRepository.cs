using System.Linq.Expressions;
using DomainDrivenDesign_Poc.Business.Domain.Entities;

namespace DomainDrivenDesign_Poc.Infraestrutura.Interface;

public interface IStudentRepository
{
    Task<bool> SaveAsync(Student student);
    Task<bool> ExistAsync(Expression<Func<Student, bool>> predicate);
    Task<Student?> FindByPredicateAsync(Expression<Func<Student, bool>> predicate);
}