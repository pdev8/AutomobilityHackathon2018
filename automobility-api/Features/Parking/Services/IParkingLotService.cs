using System.Collections.Generic;
using System.Threading.Tasks;
using automobility_api.Features.Parking.Models;

namespace automobility_api.Features.Parking.Services
{
    public interface IParkingLotService
    {
        void Seed();
        Task<IEnumerable<ParkingSpace>> GetAllParkingSpaces();
    }
}