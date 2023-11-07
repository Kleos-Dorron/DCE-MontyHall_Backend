using Microsoft.AspNetCore.Mvc;
using MontyHall_Backend.Models;
using MontyHall_Backend.Services;

namespace MontyHall_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly MontyHallService _montyHallService;

        public GameController(MontyHallService montyHallService)
        {
            _montyHallService = montyHallService;
        }

        [HttpPost("simulate")]
        public IActionResult SimulateGame([FromBody] SimulationRequest request)
        {
            MontyHallResult result = _montyHallService.SimulateGame(request.NumSimulations, request.ChangeDoor);
            return Ok(result);
        }
    }
}
