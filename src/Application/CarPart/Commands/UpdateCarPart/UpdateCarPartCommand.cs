using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Exceptions;
using ExampleProject.Application.Common.Interfaces;
using MediatR;

namespace ExampleProject.Application.CarPart.Commands.UpdateCarPart
{
    public class UpdateCarPartCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
    
    public class UpdateCarPartCommandHandler : IRequestHandler<UpdateCarPartCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCarPartCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCarPartCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CarParts.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }

            entity.Name = request.Name;
            entity.Price = request.Price;

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}