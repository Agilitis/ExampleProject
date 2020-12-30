using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Exceptions;
using ExampleProject.Application.Common.Interfaces;
using MediatR;

namespace ExampleProject.Application.Service.Commands.UpdateService
{
    public class UpdateServiceCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ServicePartnerId { get; set; }
    }
    
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateServiceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Services.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }

            entity.CarId = request.CarId;
            entity.ServicePartnerId = request.ServicePartnerId;

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}