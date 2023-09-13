
using MyMoneyManager.Application.Common.Interfaces;
using MyMoneyManager.Domain.Entities;
using MyMoneyManager.Domain.Enums;

namespace MyMoneyManager.Application.Features.Movements.GetMovements;


public class GetMovementsQuery : IRequest<GetMovementsResponse>
{
    public int BankAccountId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public class GetMovementsHandler : IRequestHandler<GetMovementsQuery, GetMovementsResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IUser _user;


    public GetMovementsHandler(IApplicationDbContext context, IUser user)
    {
        _context = context;
        _user = user;
    }

    public async Task<GetMovementsResponse> Handle(GetMovementsQuery request, CancellationToken cancellationToken)
    {
        var bankAccount = await _context.BankAccounts
            .Where(x => x.Id == request.BankAccountId)
            .FirstOrDefaultAsync(cancellationToken) ??
                throw new NotFoundException( request.BankAccountId.ToString(), nameof(BankAccount));

        var vm = new GetMovementsResponse
        {
            BankAccountId = bankAccount.Id,
            BankAccountName = bankAccount.Name,
            BankAccountDescription = bankAccount.Description,
            Balance = bankAccount.CurrentBalance
        };

        var incomes = await _context.Incomes
            .Where(x => x.BankAccountId == request.BankAccountId && x.Date >= request.StartDate && x.Date <= request.EndDate)
            .Select(x => new GetMovementsResponse.GetMovementsItem
            {
                Id = x.Id,
                Amount = x.Amount,
                Description = x.Description,
                Date = x.Date,
                Type = RecurringMovementType.Income,
                Category = x.Category.Name
            })
            .ToListAsync(cancellationToken);

        var egresses = await _context.Egresses
            .Where(x => x.BankAccountId == request.BankAccountId && x.Date >= request.StartDate && x.Date <= request.EndDate)
            .Select(x => new GetMovementsResponse.GetMovementsItem
            {
                Id = x.Id,
                Amount = x.Amount,
                Description = x.Description,
                Date = x.Date,
                Type = RecurringMovementType.Egress,
                Category = x.Category.Name
            })
            .ToListAsync(cancellationToken);

        // TODO: Obtener los movimientos de la cuenta bancaria programados del mes

        vm.Movements.AddRange(incomes);
        vm.Movements.AddRange(egresses);
        vm.Movements = vm.Movements.OrderBy(x => x.Date).ToList();

        return vm;
    }
}

public class GetMovementsResponse
{
    public int BankAccountId { get; set; }
    public string BankAccountName { get; set; } = string.Empty;
    public string BankAccountDescription { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public List<GetMovementsItem> Movements { get; set; } = new();
    public class GetMovementsItem
    {
        public RecurringMovementType Type { get; internal set; }
        public DateTime Date { get; internal set; }
        public string Description { get; internal set; } = string.Empty;
        public decimal Amount { get; internal set; }
        public int Id { get; internal set; }
        public string Category { get; set; } = string.Empty;
    }
}
