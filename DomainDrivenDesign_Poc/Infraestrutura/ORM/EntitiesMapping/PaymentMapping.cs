using DomainDrivenDesign_Poc.Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainDrivenDesign_Poc.Business.Domain.Entities;
using DomainDrivenDesign_Poc.Infraestrutura.ORM.EntitiesMapping.Base;

namespace DomainDrivenDesign_Poc.Infraestrutura.ORM.EntitiesMapping;

public sealed class PaymentMapping : BaseMapping, IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable(nameof(Payment), Schema);
        builder.HasKey(s => s.Id);

        builder.Property(n => n.Number)
            .HasColumnName("number")
            .HasColumnType("varchar(250)")
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(s => s.PaidDate)
            .HasColumnName("paid_date")
            .HasColumnType("datetime2")
            .HasColumnOrder(2);

        builder.OwnsOne(s => s.Email, email =>
        {
            email.Property(e => e.Value)
                .HasColumnName("email")
                .HasColumnType("varchar(150)")
                .HasColumnOrder(3)
                .IsRequired();
        });

        builder.OwnsOne(d => d.Document, document =>
        {
            document.Property(e => e.Value)
                .HasColumnName("document")
                .HasColumnType("varchar(150)")
                .HasColumnOrder(4)
                .IsRequired();
        });

        builder.Property(n => n.Payer)
            .HasColumnName("payer")
            .HasColumnType("varchar(250)")
            .HasColumnOrder(5)
            .IsRequired();

        builder.Property(n => n.Total)
            .HasColumnName("total")
            .HasColumnType("decimal(18,2)")
            .HasColumnOrder(6)
            .IsRequired();

        builder.Property(n => n.TotalPaid)
            .HasColumnName("total_paid")
            .HasColumnType("decimal(18,2)")
            .HasColumnOrder(7)
            .IsRequired();
        
        builder.Property(s => s.ExpireDate)
            .HasColumnName("expire_date")
            .HasColumnType("datetime2")
            .HasColumnOrder(8);

        builder.HasOne(p => p.Subscription)
            .WithMany(s => s.Payments)
            .HasForeignKey(s => s.SubscriptionId);
    }
}