using MyMoneyManager.Application.Common.Extensions;
using MyMoneyManager.Domain.Entities;
using MyMoneyManager.Domain.Enums;

namespace MyMoneyManager.Application.Features.BankAccounts.Queries.GetBankAccounts;

public class GetBankAccountsResponse
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal CurrentBalance { get; set; }
    public DateTime Date { get; set; }
    public bool Active { get; set; }
    public BankAccountType Type { get; set; }
    public string TypeDescription { get; set; } = null!;

    private class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BankAccount, GetBankAccountsResponse>()
                .ForMember(d => d.TypeDescription, opt => opt.MapFrom(s => s.Type.GetDescription()));
        }
    }
}


