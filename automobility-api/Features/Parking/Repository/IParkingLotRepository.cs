using System.Collections.Generic;
using System.Threading.Tasks;
using automobility_api.Features.Parking.Models;

namespace automobility_api.Features.Parking.Repository
{
    public interface IParkingLotRepository
    {
        void Add(ParkingSpace parkingSpace);
        Task<ParkingSpace> GetParkingSpace(string id);
        Task<IEnumerable<ParkingSpace>> GetParkingSpaces();
        Task<bool> SaveAll();

    }
}