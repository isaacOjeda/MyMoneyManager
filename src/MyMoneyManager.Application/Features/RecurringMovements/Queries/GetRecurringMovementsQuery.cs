using MyMoneyManager.Application.Common.Interfaces;
using MyMoneyManager.Application.Common.Mappings;

namespace MyMoneyManager.Application.Features.RecurringMovements.Queries;
public class GetRecurringMovementsQuery : IRequest<List<GetRecurringMovementsResponse>>
{
}


public class GetRecurringMovementsQueryHandler : IRequestHandler<GetRecurringMovementsQuery, List<GetRecurringMovementsResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRecurringMovementsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public Task<List<GetRecurringMovementsResponse>> Handle(GetRecurringMovementsQuery request, CancellationToken cancellationToken) =>
        _context.RecurringMovements
            .ProjectToListAsync<GetRecurringMovementsResponse>(_mapper.ConfigurationProvider);
}
