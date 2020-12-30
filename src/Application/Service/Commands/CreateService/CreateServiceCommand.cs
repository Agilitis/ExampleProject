using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Interfaces;
using MediatR;

namespace ExampleProject.Application.Service.Commands.CreateService
{
    public class CreateServiceCommand : IRequest<int>
    {
        public int CarId { get; set; }
        public int ServicePartnerId { get; set; }
        public IEnumerable<Domain.Entities.CarPart> CarPartsToReplace { get; set; }
    }
    
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateServiceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Domain.Entities.Service
            {
                ServicePartnerId = request.ServicePartnerId,
                CarId = request.CarId,
                CarPartsToReplace = request.CarPartsToReplace
            };

            await _context.Services.AddAsync(service, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return service.Id;
        }
    }
}