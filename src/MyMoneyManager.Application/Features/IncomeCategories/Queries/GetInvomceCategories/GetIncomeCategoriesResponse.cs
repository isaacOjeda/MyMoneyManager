using MyMoneyManager.Domain.Entities;

namespace MyMoneyManager.Application.Features.IncomeCategories.Queries.GetInvomceCategories;

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
