using System.Collections.Generic;
using static automobility_api.Features.GoogleMaps.Directions.Models.DirectionResponse;

namespace automobility_api.Features.GoogleMaps.Directions.Models.DTOs
{
    public class DirectionResponseDTO
    {
         public List<GeocodedWaypoint> geocoded_waypoints { get; set; }
            public List<Route> routes { get; set; }
            public string status { get; set; }
    }
}