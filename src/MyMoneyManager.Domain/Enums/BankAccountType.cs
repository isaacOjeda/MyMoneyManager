using System.ComponentModel;

namespace MyMoneyManager.Domain.Enums;

public enum BankAccountType
{
    [Description("Cuenta de cheques")]
    CheckingAccount,
    [Description("Cuenta de ahorros")]
    SavingsAccount,
    [Description("Cuenta de inversión")]
    InvestmentAccount,
    [Description("Tarjeta de crédito")]
    CreditCard,
    [Description("Otro")]
    Other
}
