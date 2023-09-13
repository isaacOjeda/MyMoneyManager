
using MyMoneyManager.Application.Common.Interfaces;
using MyMoneyManager.Domain.Entities;
using MyMoneyManager.Domain.Enums;
using MyMoneyManager.Domain.Events;

namespace MyMoneyManager.Application.Features.Movements.Commands.CreateMovement;

public class CreateMovementCommand : IRequest
{
    public DateTime? Date { get; set; }
    public decimal Amount { get; set; }
    public int BankAccountId { get; set; }
    public string Description { get; set; } = string.Empty;
    public RecurringMovementType Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? IncomeCategoryId { get; set; }
    public int? EgressCategoryId { get; set; }
}

public class CreateMovementCommandHandler : IRequestHandler<CreateMovementCommand>
{
    private readonly IApplicationDbContext _context;

    private readonly IUser _user;


    public CreateMovementCommandHandler(IApplicationDbContext context, IUser user)
    {
        _context = context;
        _user = user;
    }

    public async Task Handle(CreateMovementCommand request, CancellationToken cancellationToken)
    {
        if (request.Type == RecurringMovementType.Egress)
        {
            await CreateEgressAsync(request, cancellationToken);
        }
        else if (request.Type == RecurringMovementType.Income)
        {
            await CreateIncomeAsync(request, cancellationToken);
        }

        await _context.SaveChangesAsync(cancellationToken);
    }

    private async Task CreateIncomeAsync(CreateMovementCommand request, CancellationToken cancellationToken)
    {
        var income = new Income
        {
            Amount = request.Amount,
            BankAccountId = request.BankAccountId,
            Date = request.Date ?? DateTime.Now,
            Description = request.Description,
            Name = request.Name,
            IncomeCategoryId = request.IncomeCategoryId.GetValueOrDefault()
        };

        income.DomainEvents.Append(new IncomeOrEgressCreated
        {
            Amount = income.Amount,
            BankAccountId = income.BankAccountId,
            Type = RecurringMovementType.Income,
        });

        await _context.Incomes.AddAsync(income, cancellationToken);

        // Actualizar balance
        var bankAccount = await _context.BankAccounts.FindAsync(request.BankAccountId, cancellationToken)
            ?? throw new NotFoundException(request.BankAccountId.ToString(), nameof(BankAccount));

        bankAccount.CurrentBalance += request.Amount;
    }


    private async Task CreateEgressAsync(CreateMovementCommand request, CancellationToken cancellationToken)
    {
        var egress = new Egress
        {
            Amount = request.Amount,
            BankAccountId = request.BankAccountId,
            Date = request.Date ?? DateTime.Now,
            Description = request.Description,
            Name = request.Name,
            EgressCategoryId = request.EgressCategoryId.GetValueOrDefault()
        };

        egress.DomainEvents.Append(new IncomeOrEgressCreated
        {
            Amount = egress.Amount,
            BankAccountId = egress.BankAccountId,
            Type = RecurringMovementType.Egress,
        });

        await _context.Egresses.AddAsync(egress, cancellationToken);

        // Actualizar el balance
        var bankAccount = await _context.BankAccounts.FindAsync(request.BankAccountId, cancellationToken)
            ?? throw new NotFoundException(request.BankAccountId.ToString(), nameof(BankAccount));

        bankAccount.CurrentBalance -= request.Amount;
    }
}

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
