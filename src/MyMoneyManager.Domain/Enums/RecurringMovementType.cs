using System.ComponentModel;

namespace MyMoneyManager.Domain.Enums;

public enum RecurringMovementType
{
    [Description("Ingreso")]
    Income,
    [Description("Egreso")]
    Egress
}
