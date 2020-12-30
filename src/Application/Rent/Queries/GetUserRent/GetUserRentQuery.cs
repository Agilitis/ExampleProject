using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Application.Rent.Queries.GetUserRent
{
    public class GetUserRentQuery : IRequest<IEnumerable<Domain.Entities.Rent>>
    {
        public string UserId { get; set; }
    }
    
    public class GetUserRentQueryHandler : IRequestHandler<GetUserRentQuery, IEnumerable<Domain.Entities.Rent>>
    {
        private readonly IApplicationDbContext _context;

        public GetUserRentQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Rent>> Handle(GetUserRentQuery request, CancellationToken cancellationToken)
        {
            return await _context.Rents
                .Where(x => x.UserId == request.UserId)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}