using System.Threading.Tasks;
using automobility_api.Features.Parking.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace automobility_api.Features.Parking.Controllers
{
    [Route("api/[Controller]")]
    public class ParkingLotController : Controller
    {
        private readonly IParkingLotService _service;

        public ParkingLotController(IParkingLotService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("seedDB")]
        public void GetBorrowers()
        {
            _service.Seed();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllParkingSpaces()
        {
            var spaces =  _service.GetAllParkingSpaces();

            return Ok(spaces);
        }
    }
}