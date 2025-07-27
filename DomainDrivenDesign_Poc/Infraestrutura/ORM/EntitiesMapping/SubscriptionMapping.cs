using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainDrivenDesign_Poc.Business.Domain.Entities;
using DomainDrivenDesign_Poc.Infraestrutura.ORM.EntitiesMapping.Base;

namespace DomainDrivenDesign_Poc.Infraestrutura.ORM.EntitiesMapping;

public sealed class SubscriptionMapping : BaseMapping, IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable(nameof(Subscription), Schema);
        builder.HasKey(s => s.Id);

        builder.Property(s => s.IsActive)
            .HasColumnName("isActive")
            .HasColumnType("bit")
            .HasColumnOrder(1);

        builder.Property(s => s.CreateDate)
            .HasColumnName("create_date")
            .HasColumnType("datetime2")
            .HasColumnOrder(2);

        builder.Property(s => s.ExpireDate)
            .HasColumnName("expire_date")
            .HasColumnType("datetime2")
            .HasColumnOrder(3);

        builder.Property(s => s.LastUpdateDate)
            .HasColumnName("last_updateDate")
            .HasColumnType("datetime2")
            .HasColumnOrder(4);

        builder.Property(s => s.TypeSubscription)
            .HasColumnName("subscription_type")
            .HasColumnType("tinyint")
            .HasColumnOrder(5);

        builder.HasMany(s => s.Payments)
            .WithOne(s => s.Subscription)
            .HasForeignKey(p => p.SubscriptionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}