
using Microsoft.Extensions.Logging;
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
    private readonly ILogger<UpdateBalanceCommandHandler> _logger;

    public UpdateBalanceCommandHandler(IApplicationDbContext context, ILogger<UpdateBalanceCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Handle(UpdateBalanceCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = await _context.BankAccounts.FindAsync(request.Id)
            ?? throw new NotFoundException(request.Id.ToString(), nameof(BankAccount));


        bankAccount.CurrentBalance = request.NewBalance;

        _logger.LogWarning("Bank account {Id} balance updated to {NewBalance}", bankAccount.Id, bankAccount.CurrentBalance);
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}
