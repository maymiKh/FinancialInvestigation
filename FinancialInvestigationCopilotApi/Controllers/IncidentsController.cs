using FinancialInvestigationCopilotApi.Models;
using FinancialInvestigationCopilotData.Entities;
using FinancialInvetigationApp.Features.Incidents.Commands.CreateIncident;
using FinancialInvetigationApp.Features.Incidents.Commands.UpdateIncidentStatus;
using FinancialInvetigationApp.Features.Incidents.Querries.GetAllIncidents;
using FinancialInvetigationApp.Features.Incidents.Querries.GetIncidentById;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<IActionResult> CreateIncident([FromBody] CreateIncidentCommand command, CancellationToken cancellationToken)
        {
            var incident = await _mediator.Send(command, cancellationToken);

            return CreatedAtAction(
                nameof(GetIncidentById),
                new { id = incident.Id },
                incident);
        }

        [HttpPatch("{id:int}/status")]
        public async Task<IActionResult> UpdateIncident(int id, [FromBody] UpdateIncidentStatusRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new UpdateIncidentStatusCommand(id, request.Status), cancellationToken);

            if (result is null)
            {
                return NotFound(new
                {
                    message = $"Incident {id} was not found."
                });
            }

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetIncidentById(int id, CancellationToken cancellationToken)
        {
            var incident = await _mediator.Send(new GetIncidentByIdQuery(id), cancellationToken);

            if (incident is null)
            {
                return NotFound();
            }

            return Ok(incident);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIncidents(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllIncidentQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
