using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using automobility_api.Data;
using automobility_api.Features.Parking.Models;
using Microsoft.EntityFrameworkCore;

namespace automobility_api.Features.Parking.Repository
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly DataContext _context;

        public ParkingLotRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(ParkingSpace parkingSpace)
        {
            _context.Add(parkingSpace);
        }

        public async Task<ParkingSpace> GetParkingSpace(string id)
        {
            var space = await _context.ParkingSpaces.FirstOrDefaultAsync(s => s.SpaceId == id);

            return space;
        }


        public async Task<IEnumerable<ParkingSpace>> GetParkingSpaces()
        {
            var spaces = await _context.ParkingSpaces.ToListAsync();

            return spaces;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}