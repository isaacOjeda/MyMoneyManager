namespace MyMoneyManager.Application.Features.BankAccounts.Commants.CreateBankAccount;

public class CreateBankAccountValidator : AbstractValidator<CreateBankAccountCommand>
{
    public CreateBankAccountValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Description)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Type)
            .IsInEnum()
            .NotEmpty();
    }
}
