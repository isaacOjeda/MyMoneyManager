using System.ComponentModel;

namespace MyMoneyManager.Domain.Enums;

[Flags]
public enum MovementPeriodicity
{
    [Description("Diario")]
    Daily = 1,
    [Description("Semanal")]
    Weekly = 2,
    [Description("Quincenal")]
    Monthly = 4,
    [Description("Bimensual")]
    Bimonthly = 8,
    [Description("Trimestral")]
    Quarterly = 16,
    [Description("Semestral")]
    Semiannual = 32,
    [Description("Anual")]
    Annual = 64
}
