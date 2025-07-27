using Microsoft.EntityFrameworkCore;
using DomainDrivenDesign_Poc.Business.Domain.Entities;

namespace DomainDrivenDesign_Poc.Infraestrutura.ORM.Context;

public sealed class ApplicationContext(DbContextOptions<ApplicationContext> dbContext) : DbContext(dbContext)
{
    public DbSet<Student> Students { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}