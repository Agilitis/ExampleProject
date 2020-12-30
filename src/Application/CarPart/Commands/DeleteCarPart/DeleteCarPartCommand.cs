using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Car.Commands.DeleteCar;
using ExampleProject.Application.Common.Exceptions;
using ExampleProject.Application.Common.Interfaces;
using MediatR;

namespace ExampleProject.Application.CarPart.Commands.DeleteCarPart
{
    public class DeleteCarPartCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
    
    public class DeleteCarPartCommandHandler : IRequestHandler<DeleteCarCommand, Unit>
    {
        private IApplicationDbContext _context;

        public DeleteCarPartCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CarParts.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }

            _context.CarParts.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}