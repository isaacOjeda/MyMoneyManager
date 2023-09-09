namespace MyMoneyManager.Domain.Entities;
public class BankAccount : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal CurrentBalance { get; set; }
    public bool Active { get; set; }
    public BankAccountType Type { get; set; }
    public ICollection<RecurringMovement> RecurringMovements { get; set; } =
        new HashSet<RecurringMovement>();
    public ICollection<Income> Incomes { get; set; } =
        new HashSet<Income>();
    public ICollection<Egress> Egresses { get; set; } =
        new HashSet<Egress>();
}
