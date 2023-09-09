using MediatR;
using MyMoneyManager.Api.Infrastructure;
using MyMoneyManager.Application.Features.BankAccounts.Queries.GetBankAccounts;

namespace MyMoneyManager.Api.Endpoints;

public class BankAccounts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetBankAccounts);
    }

    public Task<List<GetBankAccountsResponse>> GetBankAccounts(ISender sender) =>
        sender.Send(new GetBankAccountsQuery());
}
