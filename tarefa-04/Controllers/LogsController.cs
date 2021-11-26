using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using tarefa_04.Dtos;

namespace tarefa_04.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly IHubContext<LogHub> _hubContext;
        public LogsController(IHubContext<LogHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task AddLog(AddLogDto addLogDto)
        {
            await _hubContext.Clients.All.SendAsync("logReceived", addLogDto);
        }
    }
}
