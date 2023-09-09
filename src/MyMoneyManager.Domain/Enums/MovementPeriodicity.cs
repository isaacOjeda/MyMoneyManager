using System.ComponentModel;

namespace MyMoneyManager.Domain.Enums;

public enum MovementPeriodicity
{
    [Description("Diario")]
    Daily,
    [Description("Semanal")]
    Weekly,
    [Description("Quincenal")]
    Monthly,
    [Description("Bimensual")]
    Bimonthly,
    [Description("Trimestral")]
    Quarterly,
    [Description("Semestral")]
    Semiannual,
    [Description("Anual")]
    Annual
}
