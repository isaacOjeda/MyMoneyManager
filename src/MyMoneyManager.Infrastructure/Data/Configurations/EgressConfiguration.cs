using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMoneyManager.Domain.Entities;

namespace MyMoneyManager.Infrastructure.Data.Configurations;
public class EgressConfiguration : IEntityTypeConfiguration<Egress>
{
    public void Configure(EntityTypeBuilder<Egress> builder)
    {
        builder.Property(q => q.Name)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(q => q.Description)
            .HasMaxLength(500);

        builder.Property(q => q.Amount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasOne(q => q.Category)
            .WithMany(q => q.Egresses)
            .HasForeignKey(q => q.EgressCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(q => q.BankAccount)
            .WithMany(q => q.Egresses)
            .HasForeignKey(q => q.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(q => q.TenantId)
            .IsRequired();
    }
}
