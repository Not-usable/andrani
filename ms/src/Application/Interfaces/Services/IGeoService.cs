using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IGeoService
    {
        Task<GeoResponseMessage> CompleteCoordinatesAsync(GeoRequestMessage request);
    }
}
