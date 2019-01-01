using automobility_api.Features.GoogleMaps.Directions.Models;
using automobility_api.Features.GoogleMaps.Directions.Models.DTOs;

namespace automobility_api.Features.GoogleMaps.Directions.Services
{
    public interface IDirectionService
    {
        DirectionResponseDTO GetDirection(Location location);
    }
}