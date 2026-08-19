using FinancialInvetigationApp.Features.Incidents.Commands.CreateIncident;
using FinancialInvetigationApp.Features.Incidents.Querries.GetIncidentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialInvestigationCopilotApi.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IncidentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncident([FromBody] CreateIncidentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncidentById(int id)
        {
            var result = await _mediator.Send(new GetIncidentByIdQuery(id));
            return Ok(result);
        }
    }
}
