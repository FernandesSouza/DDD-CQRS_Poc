using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainDrivenDesign_Poc.Business.Domain.Entities;
using DomainDrivenDesign_Poc.Infraestrutura.ORM.EntitiesMapping.Base;

namespace DomainDrivenDesign_Poc.Infraestrutura.ORM.EntitiesMapping;

public sealed class StudentMapping : BaseMapping, IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable(nameof(Student), Schema);
        builder.HasKey(s => s.Id);

        builder.Property(c => c.FullName)
            .HasColumnName("full_name")
            .HasColumnType("varchar(150)")
            .HasColumnOrder(1)
            .IsRequired();

        builder.OwnsOne(s => s.Email, email =>
        {
            email.Property(e => e.Value)
                .HasColumnName("email")
                .HasColumnType("varchar(150)")
                .HasColumnOrder(2)
                .IsRequired();
        });

        builder.OwnsOne(d => d.Document, document =>
        {
            document.Property(e => e.Value)
                .HasColumnName("document")
                .HasColumnType("varchar(150)")
                .HasColumnOrder(3)
                .IsRequired();
        });

        builder.HasOne(s => s.Subscription)
            .WithOne(sb => sb.Student)
            .HasForeignKey<Subscription>(s => s.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}