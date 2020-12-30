using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Application.Rent.Queries.GetAllRent
{
    public class GetAllRentQuery : IRequest<IEnumerable<Domain.Entities.Rent>>
    {
        
    }
    
    public class GetAllRentQueryHandler : IRequestHandler<GetAllRentQuery, IEnumerable<Domain.Entities.Rent>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllRentQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Rent>> Handle(GetAllRentQuery request, CancellationToken cancellationToken)
        {
            return await _context.Rents
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}