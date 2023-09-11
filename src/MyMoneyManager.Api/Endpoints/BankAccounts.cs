using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyMoneyManager.Api.Infrastructure;
using MyMoneyManager.Application.Features.BankAccounts.Commants.CreateBankAccount;
using MyMoneyManager.Application.Features.BankAccounts.Commants.DeleteBankAccount;
using MyMoneyManager.Application.Features.BankAccounts.Commants.UpdateBalance;
using MyMoneyManager.Application.Features.BankAccounts.Commants.UpdateBankAccount;
using MyMoneyManager.Application.Features.BankAccounts.Queries.GetBankAccounts;

namespace MyMoneyManager.Api.Endpoints;

public class BankAccounts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetBankAccounts)
            .MapPost(CreateBankAccount)
            .MapPut(UpdateBankAccount, "")
            .MapDelete(DeleteBankAccount, "{Id}")
            .MapPut(UpdateBalance, "balance");
    }

    public Task<List<GetBankAccountsResponse>> GetBankAccounts(ISender sender) =>
        sender.Send(new GetBankAccountsQuery());

    public async Task<IResult> CreateBankAccount(ISender sender, CreateBankAccountCommand command)
    {
        await sender.Send(command);

        return Results.NoContent();
    }

    public async Task<IResult> UpdateBankAccount(ISender sender, UpdateBankAccountCommand command)
    {
        await sender.Send(command);

        return Results.NoContent();
    }

    public async Task<IResult> DeleteBankAccount(ISender sender, [AsParameters] DeleteBankAccountCommand command)
    {
        await sender.Send(command);

        return Results.NoContent();
    }

    public async Task<IResult> UpdateBalance(ISender sender, UpdateBalanceCommand command)
    {
        await sender.Send(command);

        return Results.NoContent();
    }
}
