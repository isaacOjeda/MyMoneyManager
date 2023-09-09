namespace MyMoneyManager.Domain.Entities;


public class EgressCategory : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Active { get; set; }

    public ICollection<Egress> Egresses { get; set; } = null!;
}
