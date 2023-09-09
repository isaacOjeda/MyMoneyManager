using MyMoneyManager.Application.Common.Interfaces;
using MyMoneyManager.Application.Common.Mappings;

namespace MyMoneyManager.Application.Features.EgressCategories.GetEgressCategories;
public class GetEgressCategoriesQuery : IRequest<List<GetEgressCategoriesResponse>>
{
}

public class GetEgressCategoriesHandler : IRequestHandler<GetEgressCategoriesQuery, List<GetEgressCategoriesResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEgressCategoriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public Task<List<GetEgressCategoriesResponse>> Handle(GetEgressCategoriesQuery request, CancellationToken cancellationToken) =>
        _context.EgressCategories
            .ProjectToListAsync<GetEgressCategoriesResponse>(_mapper.ConfigurationProvider);
}
