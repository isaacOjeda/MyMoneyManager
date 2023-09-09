using MyMoneyManager.Application.Common.Interfaces;
using MyMoneyManager.Domain.Entities;
using MyMoneyManager.Domain.Enums;

namespace MyMoneyManager.Application.Features.BankAccounts.Commants.CreateBankAccount;
public class CreateBankAccountCommand : IRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal CurrentBalance { get; set; }
    public BankAccountType Type { get; set; }
}

public class CreateBankAccountHandler : IRequestHandler<CreateBankAccountCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IUser _user;

    public CreateBankAccountHandler(IApplicationDbContext context, IUser user)
    {
        _context = context;
        _user = user;
    }

    public async Task Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
    {
        var newBankAccount = new BankAccount
        {
            Name = request.Name,
            Description = request.Description,
            CurrentBalance = request.CurrentBalance,
            Type = request.Type,
            UserId = _user.Id
        };

        _context.BankAccounts.Add(newBankAccount);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
