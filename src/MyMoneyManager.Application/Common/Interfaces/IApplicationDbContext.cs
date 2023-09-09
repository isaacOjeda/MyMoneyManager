using MyMoneyManager.Domain.Entities;

namespace MyMoneyManager.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<BankAccount> BankAccounts { get; }
    DbSet<Egress> Egresses { get; }
    DbSet<EgressCategory> EgressCategories { get; }
    DbSet<Income> Incomes { get; }
    DbSet<IncomeCategory> IncomeCategories { get; }
    DbSet<RecurringMovement> RecurringMovements { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}