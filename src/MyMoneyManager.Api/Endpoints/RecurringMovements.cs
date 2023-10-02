using MediatR;
using MyMoneyManager.Api.Infrastructure;
using MyMoneyManager.Application.Features.RecurringMovements.Commands;
using MyMoneyManager.Application.Features.RecurringMovements.Queries;

namespace MyMoneyManager.Api.Endpoints;

public class RecurringMovements : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetRecurringMovements)
            .MapPost(CreateRecurringMovement);
    }


    public Task<List<GetRecurringMovementsResponse>> GetRecurringMovements(ISender sender) =>
        sender.Send(new GetRecurringMovementsQuery());

    public async Task<IResult> CreateRecurringMovement(ISender sender, CreateRecurringMovementCommand command)
    {
        await sender.Send(command);

        return Results.NoContent();
    }
}
