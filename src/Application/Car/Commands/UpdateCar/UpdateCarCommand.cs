using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Exceptions;
using ExampleProject.Application.Common.Interfaces;
using ExampleProject.Domain.Entities;
using ExampleProject.Domain.Enums;
using MediatR;

namespace ExampleProject.Application.Car.Commands.UpdateCar
{
    public class UpdateCarCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int MarketPrice { get; set; }
        public int DailyRentPrice { get; set; }
        public List<Accessory> Accessories { get; set; }

        public CarType Type { get; set; }
    }
    
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCarCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cars.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity), request.Id);
            }

            entity.MarketPrice = request.MarketPrice;
            entity.DailyRentPrice = request.DailyRentPrice;
            entity.Accessories = request.Accessories;
            entity.Type = request.Type;
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}