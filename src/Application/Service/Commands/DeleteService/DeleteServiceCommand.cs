using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Exceptions;
using ExampleProject.Application.Common.Interfaces;
using MediatR;

namespace ExampleProject.Application.Service.Commands.DeleteService
{
    public class DeleteServiceCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
    
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteServiceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Services.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }

            _context.Services.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}