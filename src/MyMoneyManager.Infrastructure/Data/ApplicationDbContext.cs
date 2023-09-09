using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMoneyManager.Application.Common.Interfaces;
using MyMoneyManager.Domain.Entities;
using MyMoneyManager.Infrastructure.Identity;
using System.Reflection;

namespace MyMoneyManager.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<BankAccount> BankAccounts => Set<BankAccount>();
    public DbSet<Egress> Egresses => Set<Egress>();
    public DbSet<EgressCategory> EgressCategories => Set<EgressCategory>();
    public DbSet<Income> Incomes => Set<Income>();
    public DbSet<IncomeCategory> IncomeCategories => Set<IncomeCategory>();
    public DbSet<RecurringMovement> RecurringMovements => Set<RecurringMovement>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
