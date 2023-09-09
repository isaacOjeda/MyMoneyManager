using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMoneyManager.Application.Common.Interfaces;
using MyMoneyManager.Domain.Entities;
using MyMoneyManager.Infrastructure.Identity;

namespace MyMoneyManager.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly IUser _user;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUser user)
        : base(options)
    {
        _user = user;
    }

    public DbSet<BankAccount> BankAccounts => Set<BankAccount>();
    public DbSet<Egress> Egresses => Set<Egress>();
    public DbSet<EgressCategory> EgressCategories => Set<EgressCategory>();
    public DbSet<Income> Incomes => Set<Income>();
    public DbSet<IncomeCategory> IncomeCategories => Set<IncomeCategory>();
    public DbSet<RecurringMovement> RecurringMovements => Set<RecurringMovement>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<BankAccount>()
            .HasQueryFilter(b => b.UserId == _user.Id);

        builder.Entity<Egress>()
            .HasQueryFilter(e => e.UserId == _user.Id);

        builder.Entity<Income>()
            .HasQueryFilter(i => i.UserId == _user.Id);

        builder.Entity<RecurringMovement>()
            .HasQueryFilter(rm => rm.UserId == _user.Id);


        base.OnModelCreating(builder);
    }
}
