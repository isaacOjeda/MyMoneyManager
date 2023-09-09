using MediatR;
using MyMoneyManager.Api.Infrastructure;
using MyMoneyManager.Application.Features.BankAccounts.Commants.CreateBankAccount;
using MyMoneyManager.Application.Features.BankAccounts.Queries.GetBankAccounts;

namespace MyMoneyManager.Api.Endpoints;

public class BankAccounts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetBankAccounts)
            .MapPost(CreateBankAccount);
    }

    public Task<List<GetBankAccountsResponse>> GetBankAccounts(ISender sender) =>
        sender.Send(new GetBankAccountsQuery());

    public async Task<IResult> CreateBankAccount(ISender sender, CreateBankAccountCommand command)
    {
        await sender.Send(command);

        return Results.NoContent();
    }
}
