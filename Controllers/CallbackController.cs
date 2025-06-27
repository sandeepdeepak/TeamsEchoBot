using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph.Communications.Calls;
using Microsoft.Graph.Communications.Client;
using Microsoft.Graph.Communications.Common.Telemetry;
using System.Threading.Tasks;

namespace TeamsEchoBot.Controllers
{
    [ApiController]
    [Route("/callback")]
    public class CallbackController : ControllerBase
    {
        private readonly BotService _botService;

        public CallbackController(BotService botService)
        {
            _botService = botService;
        }

        [HttpPost]
        public async Task<IActionResult> OnIncomingCall()
        {
            await _botService.HandleCallbackAsync(Request);
            return Ok();
        }
    }
}