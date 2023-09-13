namespace MyMoneyManager.Domain.Events;

public class IncomeOrEgressCreated : BaseEvent
{
    public decimal Amount {get;set;}
    public string UserId {get;set;} = string.Empty;
    public int BankAccountId { get; set; }
    public RecurringMovementType Type { get; set; }
}
