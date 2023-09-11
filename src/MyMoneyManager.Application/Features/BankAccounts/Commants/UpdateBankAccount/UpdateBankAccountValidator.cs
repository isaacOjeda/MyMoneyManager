namespace MyMoneyManager.Application.Features.BankAccounts.Commants.UpdateBankAccount;

public class UpdateBankAccountValidator : AbstractValidator<UpdateBankAccountCommand>
{
    public UpdateBankAccountValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
        RuleFor(v => v.Name).NotEmpty().MaximumLength(250);
        RuleFor(v => v.Description).NotEmpty().MaximumLength(500);
        RuleFor(v => v.Type).NotEmpty();
    }

}
