using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Interfaces;
using MediatR;

namespace ExampleProject.Application.ServicePartner.Commands.CreateServicePartner
{
    public class CreateServicePartnerCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int ServiceFee { get; set; }
        public string Address { get; set; }
    }
    
    public class CreateServicePartnerCommandHandler : IRequestHandler<CreateServicePartnerCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateServicePartnerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateServicePartnerCommand request, CancellationToken cancellationToken)
        {
            var servicePartner = new Domain.Entities.ServicePartner
            {
                Name = request.Name,
                ServiceFee = request.ServiceFee,
                Address = request.Address
            };

            _context.ServicePartners.Add(servicePartner);

            await _context.SaveChangesAsync(cancellationToken);

            return servicePartner.Id;
        }
    }
}