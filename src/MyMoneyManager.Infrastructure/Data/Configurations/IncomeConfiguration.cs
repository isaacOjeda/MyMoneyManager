using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMoneyManager.Domain.Entities;

namespace MyMoneyManager.Infrastructure.Data.Configurations;
public class IncomeConfiguration : IEntityTypeConfiguration<Income>
{
    public void Configure(EntityTypeBuilder<Income> builder)
    {
        builder.Property(q => q.Name)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(q => q.Description)
            .HasMaxLength(500);

        builder.Property(q => q.Amount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(q => q.Date)
            .IsRequired();

        builder.HasOne(q => q.IncomeCategory)
            .WithMany(q => q.Incomes)
            .HasForeignKey(q => q.IncomeCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(q => q.BankAccount)
            .WithMany(q => q.Incomes)
            .HasForeignKey(q => q.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(q => q.TenantId)
            .IsRequired();
    }
}
