using Microsoft.AspNetCore.Mvc;
using NHS111.Logging.Api.Services;

namespace NHS111.Logging.Api.Controllers
{
    [ServiceFilter(typeof(ApiExceptionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        private readonly IMonitorService _monitor;

        public MonitorController(IMonitorService monitor)
        {
            _monitor = monitor;
        }

        [HttpGet]
        [Route("{service}")]
        public string MonitorPing(string service)
        {
            switch (service.ToLower())
            {
                case "ping":
                    return _monitor.Ping();

                case "metrics":
                    return _monitor.Metrics();

                case "health":
                    return _monitor.Health().ToString();

                case "version":
                    return _monitor.Version();
            }

            return null;
        }
    }
}