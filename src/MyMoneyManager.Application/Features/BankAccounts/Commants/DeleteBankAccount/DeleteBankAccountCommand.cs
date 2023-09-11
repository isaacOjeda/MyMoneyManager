
using MyMoneyManager.Application.Common.Interfaces;
using MyMoneyManager.Domain.Entities;

namespace MyMoneyManager.Application.Features.BankAccounts.Commants.DeleteBankAccount;

public class DeleteBankAccountCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteBankAccountCommandHandler : IRequestHandler<DeleteBankAccountCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteBankAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteBankAccountCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = await _context.BankAccounts.FindAsync(request.Id)
            ?? throw new NotFoundException(request.Id.ToString(), nameof(BankAccount));

        bankAccount.Active = false;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
