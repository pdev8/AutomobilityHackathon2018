using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace automobility_api.Features.Parking.Models
{
    public class ParkingSpace
    {
        [Key]
        public string SpaceId { get; set; }
        public string BlockFace { get; set; }
        public string MeterType { get; set; }
        public string RateType { get; set; }
        public string RateRange { get; set; }
        public string MeteredTimeLimit { get; set; }
        public string ParkingPolicy { get; set; }
        public string StreetCleaning { get; set; }
        public decimal  Lat{ get; set; }
        public decimal Lon {get; set;}


    }
}