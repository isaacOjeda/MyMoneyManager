using MyMoneyManager.Application.Common.Extensions;
using MyMoneyManager.Domain.Entities;
using MyMoneyManager.Domain.Enums;

namespace MyMoneyManager.Application.Features.RecurringMovements.Queries;

public class GetRecurringMovementsResponse
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Amount { get; set; }
    public MovementPeriodicity Periodicity { get; set; }
    public string PeriodicityDescription { get; set; } = null!;
    public int? DayOfWeek { get; set; }
    public int? DayOfMonth { get; set; }
    public int? Month { get; set; }
    public DateTime? Expires { get; set; }
    public int BankAccountId { get; set; }
    public string BankAccountDescription { get; set; } = null!;

    private class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RecurringMovement, GetRecurringMovementsResponse>()
                .ForMember(d => d.PeriodicityDescription, opt => opt.MapFrom(s => s.Periodicity.GetDescription()))
                .ForMember(d => d.BankAccountDescription, opt => opt.MapFrom(s => s.BankAccount.Description));
        }
    }
}
