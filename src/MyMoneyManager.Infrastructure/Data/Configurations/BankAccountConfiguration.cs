using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMoneyManager.Domain.Entities;

namespace MyMoneyManager.Infrastructure.Data.Configurations;
public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.Property(q => q.Name)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(q => q.Description)
            .HasMaxLength(500);

        builder.Property(q => q.CurrentBalance)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(q => q.UserId)
            .IsRequired();
    }
}
