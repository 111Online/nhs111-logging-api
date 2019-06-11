using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NHS111.Logging.Api.Models;
using NHS111.Logging.Api.Services;

namespace NHS111.Logging.Api.Controllers
{
    [ServiceFilter(typeof(ApiExceptionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        public async Task<ActionResult> Log(LogEntry log)
        {
            await _logService.Log(log);
            return Ok();
        }

        [HttpPost]
        [Route("audit")]
        public async Task<ActionResult> Audit(AuditEntry audit)
        {
            if (audit == null)
                return BadRequest("Cannot log a null AuditEntry");

            if (audit.SessionId == Guid.Empty)
                return BadRequest("AuditEntry.SessionId cannot be empty.");

            await _logService.Log(audit);
            return Ok();
        }
    }
}