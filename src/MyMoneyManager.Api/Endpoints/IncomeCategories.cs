using MediatR;
using MyMoneyManager.Api.Infrastructure;
using MyMoneyManager.Application.Features.IncomeCategories.Queries.GetInvomceCategories;

namespace MyMoneyManager.Api.Endpoints;

public class IncomeCategories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetIncomeCategories);
    }


    public Task<List<GetIncomeCategoriesResponse>> GetIncomeCategories(ISender sender) =>
        sender.Send(new GetIncomeCategoriesQuery());

}
