using System;

namespace automobility_api.Features.Parking.Models
{
    public class ParkingMeterOccupancyDTO
    {
        public string SpaceId { get; set; }
        public DateTime EventTime_UTC { get; set; }
        public string OccupancyState { get; set; }
    }
}