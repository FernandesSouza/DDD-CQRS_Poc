using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DomainDrivenDesign_Poc.Business.Domain.Entities;
using DomainDrivenDesign_Poc.Infraestrutura.Interface;
using DomainDrivenDesign_Poc.Infraestrutura.ORM.Context;

namespace DomainDrivenDesign_Poc.Infraestrutura.Repository;

public sealed class StudentRepository(
    ApplicationContext context
) : IStudentRepository
{
    private const int StandartQuantity = 0;

    public async Task<bool> SaveAsync(Student student)
    {
        await context.Students.AddAsync(student);
        return await context.SaveChangesAsync() > StandartQuantity;
    }

    public async Task<bool> ExistAsync(Expression<Func<Student, bool>> predicate) =>
        await context.Students.AnyAsync(predicate);

    public async Task<Student?> FindByPredicateAsync(Expression<Func<Student, bool>> predicate) =>
        await context.Students.FirstOrDefaultAsync(predicate);
}