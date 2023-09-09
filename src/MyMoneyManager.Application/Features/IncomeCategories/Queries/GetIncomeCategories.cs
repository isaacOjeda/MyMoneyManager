using MyMoneyManager.Application.Common.Interfaces;
using MyMoneyManager.Application.Common.Mappings;
using MyMoneyManager.Domain.Entities;

namespace MyMoneyManager.Application.Features.IncomeCategories.Queries;

public class GetIncomeCategories : IRequest<List<GetIncomeCategoriesResponse>>
{
}

public class GetIncomeCategoriesHandler : IRequestHandler<GetIncomeCategories, List<GetIncomeCategoriesResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetIncomeCategoriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<List<GetIncomeCategoriesResponse>> Handle(GetIncomeCategories request, CancellationToken cancellationToken) =>
        _context.IncomeCategories
            .ProjectToListAsync<GetIncomeCategoriesResponse>(_mapper.ConfigurationProvider);
}

public class GetIncomeCategoriesResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    private class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IncomeCategory, GetIncomeCategoriesResponse>();
        }
    }
}
