using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MontyHall_Backend.Models;
using MontyHall_Backend.Services;

namespace MontyHall_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly MontyHallService _montyHallService;

        public GameController(MontyHallService montyHallService)
        {
            _montyHallService = montyHallService;
        }

        /// <summary>
        /// This the Simulation API Post Request for MontyHall Game Paradox  
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("simulate")]
        public IActionResult SimulateGame([FromBody] SimulationRequest request)
        {
            MontyHallResult result = _montyHallService.SimulateGame(request.NumSimulations, request.ChangeDoor);
            return Ok(result);
        }
    }
}
