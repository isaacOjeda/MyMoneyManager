using MediatR;
using MyMoneyManager.Api.Infrastructure;
using MyMoneyManager.Application.Features.Movements.Commands.CreateMovement;
using MyMoneyManager.Application.Features.Movements.GetMovements;

namespace MyMoneyManager.Api.Endpoints;

public class Movements : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetMovements)
            .MapPost(CreateMovement);
    }

    public Task<GetMovementsResponse> GetMovements(ISender sender, [AsParameters] GetMovementsQuery query)
    {
        return sender.Send(query);
    }

    public async Task<IResult> CreateMovement(ISender sender, CreateMovementCommand command)
    {
        await sender.Send(command);

        return Results.NoContent();
    }
}
