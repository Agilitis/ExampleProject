using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Application.ServicePartner.Queries.GetAllServiceParnter
{
    public class GetAllServicePartnerQuery : IRequest<IEnumerable<Domain.Entities.ServicePartner>>
    {
        
    }
    
    public class GetAllServicePartnerQueryHandler : IRequestHandler<GetAllServicePartnerQuery, IEnumerable<Domain.Entities.ServicePartner>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllServicePartnerQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.ServicePartner>> Handle(GetAllServicePartnerQuery request, CancellationToken cancellationToken)
        {
            return await _context.ServicePartners
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}