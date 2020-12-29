using ExampleProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleProject.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }
        
        DbSet<Domain.Entities.Car> Cars { get; set; }

        DbSet<Accessory> Accessories { get; set; }

        DbSet<CarPart> CarParts { get; set; }

        DbSet<Rent> Rents { get; set; }

        DbSet<Service> Services { get; set; }

        DbSet<ServicePartner> ServicePartners { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
