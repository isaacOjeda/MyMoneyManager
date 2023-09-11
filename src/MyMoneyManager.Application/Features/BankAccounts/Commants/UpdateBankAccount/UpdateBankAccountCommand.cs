using MyMoneyManager.Application.Common.Interfaces;
using MyMoneyManager.Domain.Entities;
using MyMoneyManager.Domain.Enums;

namespace MyMoneyManager.Application.Features.BankAccounts.Commants.UpdateBankAccount;

public class UpdateBankAccountCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public BankAccountType Type { get; set; }
}

public class UpdateBankAccountHandler : IRequestHandler<UpdateBankAccountCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateBankAccountHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = await _context.BankAccounts.FindAsync(request.Id)
            ?? throw new NotFoundException(request.Id.ToString(), nameof(BankAccount));

        bankAccount.Name = request.Name;
        bankAccount.Description = request.Description;
        bankAccount.Type = request.Type;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
