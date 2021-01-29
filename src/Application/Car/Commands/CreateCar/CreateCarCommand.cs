using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Interfaces;
using ExampleProject.Domain.Enums;
using ExampleProject.Domain.Entities;
using ExampleProject.Domain.ValueObjects;
using MediatR;

namespace ExampleProject.Application.Car.Commands.CreateCar
{
    public class CreateCarCommand : IRequest<int>
    {
        public string CarColor { get; set; }
        public CarType Type { get; set; }
        public int DailyRentPrice { get; set; }
        public int MarketPrice { get; set; }
        public IList<Accessory> Accessories { get; set; } = new List<Accessory>();
    }

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCarCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = new Domain.Entities.Car
            {
                Type = request.Type,
                DailyRentPrice = request.DailyRentPrice,
                MarketPrice = request.MarketPrice,
                CarColor = request.CarColor
            };

            foreach (var accessory in request.Accessories)
            {
                var entity = await _context.Accessories.FindAsync(accessory.Id);
                entity.Cars.Add(car);
                car.Accessories.Add(entity);
            }

            car.DomainEvents.Add()

            _context.Cars.Add(car);

            await _context.SaveChangesAsync(cancellationToken);

            return car.Id;
        }
    }
}