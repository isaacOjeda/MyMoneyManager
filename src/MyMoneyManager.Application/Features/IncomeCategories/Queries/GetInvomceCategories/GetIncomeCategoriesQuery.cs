using MyMoneyManager.Application.Common.Interfaces;
using MyMoneyManager.Application.Common.Mappings;

namespace MyMoneyManager.Application.Features.IncomeCategories.Queries.GetInvomceCategories;

public class GetIncomeCategoriesQuery : IRequest<List<GetIncomeCategoriesResponse>>
{
}

public class GetIncomeCategoriesHandler : IRequestHandler<GetIncomeCategoriesQuery, List<GetIncomeCategoriesResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetIncomeCategoriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<List<GetIncomeCategoriesResponse>> Handle(GetIncomeCategoriesQuery request, CancellationToken cancellationToken) =>
        _context.IncomeCategories
            .ProjectToListAsync<GetIncomeCategoriesResponse>(_mapper.ConfigurationProvider);
}
