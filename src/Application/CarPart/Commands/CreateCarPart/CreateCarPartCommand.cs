using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Interfaces;
using MediatR;

namespace ExampleProject.Application.CarPart.Commands.CreateCarPart
{
    public class CreateCarPartCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
    
    public class CreateCarPartCommandHandler : IRequestHandler<CreateCarPartCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCarPartCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCarPartCommand request, CancellationToken cancellationToken)
        {
            var carPart = new Domain.Entities.CarPart
            {
                Name = request.Name,
                Price = request.Price
            };

            await _context.CarParts.AddAsync(carPart, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            
            return carPart.Id;
        }
    }
}