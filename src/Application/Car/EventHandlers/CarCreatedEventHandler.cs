using ExampleProject.Application.Common.Models;
using ExampleProject.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleProject.Application.Car.EventHandlers
{
    class CarCreatedEventHandler : INotificationHandler<DomainEventNotification<CarCreatedEvent>>
    {
        private readonly ILogger<CarCreatedEventHandler> _logger;

        public CarCreatedEventHandler(ILogger<CarCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<CarCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("ExampleProject Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
        
    }
}
