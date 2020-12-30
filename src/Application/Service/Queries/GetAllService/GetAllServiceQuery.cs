using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Application.Service.Queries.GetAllService
{
    public class GetAllServiceQuery : IRequest<IEnumerable<Domain.Entities.Service>>
    {
        
    }
    
    public class GetAllServiceQueryHandler : IRequestHandler<GetAllServiceQuery, IEnumerable<Domain.Entities.Service>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllServiceQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Service>> Handle(GetAllServiceQuery request, CancellationToken cancellationToken)
        {
            return await _context.Services
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}