using Microsoft.Extensions.Logging;
using MyMoneyManager.Domain.Events;

namespace MyMoneyManager.Application.Features.Movements.EventHandlers;

public class MovementCreatedEventHandler : INotificationHandler<IncomeOrEgressCreated>
{
    private readonly ILogger<MovementCreatedEventHandler> _logger;

    public MovementCreatedEventHandler(ILogger<MovementCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(IncomeOrEgressCreated notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("MovementCreatedEventHandler: {notification}", notification);

        return Task.FromResult(0);
    }
}
