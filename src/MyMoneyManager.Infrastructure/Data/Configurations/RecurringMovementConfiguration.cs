using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMoneyManager.Domain.Entities;

namespace MyMoneyManager.Infrastructure.Data.Configurations;
public class RecurringMovementConfiguration : IEntityTypeConfiguration<RecurringMovement>
{
    public void Configure(EntityTypeBuilder<RecurringMovement> builder)
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

        builder.HasOne(b => b.BankAccount)
            .WithMany(b => b.RecurringMovements)
            .HasForeignKey(b => b.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(q => q.UserId)
            .IsRequired();
    }
}
