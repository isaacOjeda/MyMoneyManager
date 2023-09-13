namespace MyMoneyManager.Domain.Entities;

public class Income : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public bool Active { get; set; }

    public int IncomeCategoryId { get; set; }
    public IncomeCategory Category { get; set; } = null!;
    public int BankAccountId { get; set; }
    public BankAccount BankAccount { get; set; } = null!;
}
