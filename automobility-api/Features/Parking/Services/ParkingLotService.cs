using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using automobility_api.Features.Parking.Models;
using automobility_api.Features.Parking.Repository;
using CsvHelper;
using SODA;

namespace automobility_api.Features.Parking.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IParkingLotRepository _repo;

        public ParkingLotService(IParkingLotRepository repo)
        {
            _repo = repo;
        }
        
        public void Seed()
        {
            var client = new SodaClient("https://data.lacity.org", "Zl2EBgOSHPSAFqwJIHtQHXDfk");

            var dataset = client.GetResource<ParkingSpace>("m63b-p9y6");

            var rows = dataset.GetRows(limit: 50000);

            rows.ToList().ForEach(s => 
            {
                if (s != null)
                {
                    _repo.Add(s);
                }
            });

            _repo.SaveAll();
        }

        public async Task<IEnumerable<ParkingSpace>> GetAllParkingSpaces()
        {
            var spaces = await _repo.GetParkingSpaces();

            return spaces;
        }
    }
}