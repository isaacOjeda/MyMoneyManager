using System.ComponentModel;

namespace MyMoneyManager.Domain.Enums;

public enum RecurringMovementType
{
    [Description("Ingreso")]
    Income = 1,
    [Description("Egreso")]
    Egress = 2
}
