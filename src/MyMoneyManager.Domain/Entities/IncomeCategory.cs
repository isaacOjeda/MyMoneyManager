namespace MyMoneyManager.Domain.Entities;
public class IncomeCategory : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Active { get; set; }

    public ICollection<Income> Incomes { get; set; } =
        new HashSet<Income>();
}
