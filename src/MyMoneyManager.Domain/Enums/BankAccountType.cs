using System.ComponentModel;

namespace MyMoneyManager.Domain.Enums;

[Flags]
public enum BankAccountType
{
    [Description("Cuenta de cheques")]
    CheckingAccount = 1,
    [Description("Cuenta de ahorros")]
    SavingsAccount = 2,
    [Description("Cuenta de inversión")]
    InvestmentAccount = 4,
    [Description("Tarjeta de crédito")]
    CreditCard = 8,
    [Description("Otro")]
    Other = 16
}
