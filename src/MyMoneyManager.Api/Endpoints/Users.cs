using MyMoneyManager.Api.Infrastructure;
using MyMoneyManager.Infrastructure.Identity;

namespace MyMoneyManager.Api.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapIdentityApi<ApplicationUser>();
    }
}
