using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Exceptions;
using ExampleProject.Application.Common.Interfaces;
using MediatR;

namespace ExampleProject.Application.Car.Commands.DeleteCar
{
    public class DeleteCarCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCarCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cars.FindAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity), request.Id);
            }

            _context.Cars.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}