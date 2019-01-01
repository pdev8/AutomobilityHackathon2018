using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using automobility_api.Features.GoogleMaps.Directions.Services;
using automobility_api.Features.GoogleMaps.Directions.Models;

namespace automobility_api.Features.GoogleMaps.Directions.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DirectionController : ControllerBase
    {
        private readonly IDirectionService _directionService;

        public DirectionController(IDirectionService directionService)
        {
            _directionService = directionService;
        }

        [HttpPost]
        public IActionResult GetDirection(Location location)
        {
            var values = _directionService.GetDirection(location);

            return Ok(values);
        }
    }
}