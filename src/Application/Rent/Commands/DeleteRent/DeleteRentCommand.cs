using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Exceptions;
using ExampleProject.Application.Common.Interfaces;
using MediatR;

namespace ExampleProject.Application.Rent.Commands.DeleteRent
{
    public class DeleteRentCommand : IRequest<Unit>
    {
        public int RentId { get; set; }   
    }
    
    public class DeleteRentCommandHandler : IRequestHandler<DeleteRentCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rents.FindAsync(request.RentId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }

            _context.Rents.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}