using MyMoneyManager.Application.Common.Interfaces;
using MyMoneyManager.Application.Common.Mappings;

namespace MyMoneyManager.Application.Features.BankAccounts.Queries.GetBankAccounts;
public class GetBankAccountsQuery : IRequest<List<GetBankAccountsResponse>>
{
}

public class GetBankAccountsHandler : IRequestHandler<GetBankAccountsQuery, List<GetBankAccountsResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBankAccountsHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<List<GetBankAccountsResponse>> Handle(GetBankAccountsQuery request, CancellationToken cancellationToken) =>
        _context.BankAccounts.ProjectToListAsync<GetBankAccountsResponse>(_mapper.ConfigurationProvider);
}


