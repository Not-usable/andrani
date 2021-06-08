using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IGeoService
    {
        Task<Coordinates> CompleteCoordinatesAsync(Address request);
    }
}
