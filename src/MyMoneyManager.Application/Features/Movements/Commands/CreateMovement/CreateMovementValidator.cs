using MyMoneyManager.Domain.Enums;

namespace MyMoneyManager.Application.Features.Movements.Commands.CreateMovement;

public class CreateMovementValidator : AbstractValidator<CreateMovementCommand>
{
    public CreateMovementValidator()
    {
        RuleFor(v => v.Amount)
            .NotEmpty()
            .GreaterThan(0);
        
        RuleFor(v => v.BankAccountId)
            .NotEmpty();

        RuleFor(v => v.Type)
            .NotEmpty();

        RuleFor(v => v.Name)
            .NotEmpty();

        // Si es egress, debe tener una categoría de egreso
        RuleFor(v => v.EgressCategoryId)
            .NotEmpty()
            .When(v => v.Type == RecurringMovementType.Egress);

        // Si es ingreso, debe tener una categoría de ingreso
        RuleFor(v => v.IncomeCategoryId)
            .NotEmpty()
            .When(v => v.Type == RecurringMovementType.Income);
    }
}
