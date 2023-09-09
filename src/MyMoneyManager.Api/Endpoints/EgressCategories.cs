using MediatR;
using MyMoneyManager.Api.Infrastructure;
using MyMoneyManager.Application.Features.EgressCategories.GetEgressCategories;

namespace MyMoneyManager.Api.Endpoints;

public class EgressCategories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetEgressCategories);
    }


    public Task<List<GetEgressCategoriesResponse>> GetEgressCategories(ISender sender) =>
        sender.Send(new GetEgressCategoriesQuery());

}
