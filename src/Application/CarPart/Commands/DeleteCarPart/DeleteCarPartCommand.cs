using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Car.Commands.DeleteCar;
using MediatR;

namespace ExampleProject.Application.CarPart.Commands.DeleteCarPart
{
    public class DeleteCarPartCommand : IRequest<Unit>
    {
        
    }
    
    public class DeleteCarPartCommandHandler : IRequestHandler<DeleteCarCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            
            return Unit.Value;
        }
    }
}