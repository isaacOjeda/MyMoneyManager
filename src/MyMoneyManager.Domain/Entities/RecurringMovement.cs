namespace MyMoneyManager.Domain.Entities;
public class RecurringMovement : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public bool Active { get; set; }
    public MovementPeriodicity Periodicity { get; set; }
    public int? DayOfWeek { get; set; }
    public int? DayOfMonth { get; set; }
    public int? Month { get; set; }
    public DateTime? Expires { get; set; }

    public int BankAccountId { get; set; }
    public BankAccount BankAccount { get; set; } = null!;
}
