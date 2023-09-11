
using MyMoneyManager.Application.Common.Interfaces;
using MyMoneyManager.Domain.Entities;

namespace MyMoneyManager.Application.Features.BankAccounts.Commants.UpdateBalance;

public class UpdateBalanceCommand : IRequest
{
    public int Id { get; set; }
    public decimal NewBalance { get; set; }
}

public class UpdateBalanceCommandHandler : IRequestHandler<UpdateBalanceCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateBalanceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateBalanceCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = await _context.BankAccounts.FindAsync(request.Id)
            ?? throw new NotFoundException(request.Id.ToString(), nameof(BankAccount));


        bankAccount.CurrentBalance = request.NewBalance;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
