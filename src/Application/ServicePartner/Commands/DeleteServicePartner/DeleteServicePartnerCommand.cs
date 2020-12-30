using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Exceptions;
using ExampleProject.Application.Common.Interfaces;
using MediatR;

namespace ExampleProject.Application.ServicePartner.Commands.DeleteServicePartner
{
    public class DeleteServicePartnerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
    
    public class DeleteServicePartnerCommandHandler : IRequestHandler<DeleteServicePartnerCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteServicePartnerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteServicePartnerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ServicePartners.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }

            _context.ServicePartners.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}