using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Exceptions;
using ExampleProject.Application.Common.Interfaces;
using MediatR;

namespace ExampleProject.Application.ServicePartner.Commands.UpdateServicePartner
{
    public class UpdateServicePartnerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public int ServiceFee { get; set; }
    }
    
    public class UpdateServicePartnerCommandHandler : IRequestHandler<UpdateServicePartnerCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateServicePartnerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateServicePartnerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ServicePartners.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }

            entity.Address = request.Address;
            entity.Name = request.Name;
            entity.ServiceFee = request.ServiceFee;

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}