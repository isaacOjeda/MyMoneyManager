using MyMoneyManager.Application.Common.Interfaces;
using MyMoneyManager.Domain.Entities;
using MyMoneyManager.Domain.Enums;

namespace MyMoneyManager.Application.Features.RecurringMovements.Commands;
public class CreateRecurringMovementCommand : IRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public MovementPeriodicity Periodicity { get; set; }
    public int? DayOfWeek { get; set; }
    public int? DayOfMonth { get; set; }
    public int? Month { get; set; }
    public DateTime? Expires { get; set; }
    public int BankAccountId { get; set; }
}

public class CreateRecurringMovementCommandHandler : IRequestHandler<CreateRecurringMovementCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateRecurringMovementCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateRecurringMovementCommand request, CancellationToken cancellationToken)
    {
        var newRecurring = new RecurringMovement
        {
            Active = true,
            Amount = request.Amount,
            BankAccountId = request.BankAccountId,
            Date = request.Date,
            DayOfMonth = request.DayOfMonth,
            DayOfWeek = request.DayOfWeek,
            Description = request.Description,
            Expires = request.Expires,
            Month = request.Month,
            Name = request.Name,
            Periodicity = request.Periodicity
        };

        _context.RecurringMovements.Add(newRecurring);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
