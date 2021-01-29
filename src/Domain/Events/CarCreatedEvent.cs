using ExampleProject.Domain.Common;
using ExampleProject.Domain.Entities;

namespace ExampleProject.Domain.Events
{
    public class CarCreatedEvent : DomainEvent
    {
        public CarCreatedEvent(Car car)
        {
            this.car = car;
        }

        public Car car { get; set; }
    }
}
