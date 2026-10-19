using FinancialInvestigationCopilotData.Entities;
using FinancialInvestigationCopilotData.Enum;
using FinancialInvetigationApp.DTOs;
using FinancialInvetigationApp.Interfaces;
using MediatR;

namespace FinancialInvetigationApp.Features.Incidents.Commands.CreateIncident
{
    public class CreateIncidentCommandHandler : IRequestHandler<CreateIncidentCommand, IncidentDto>
    {
        private readonly IIncidentRepository _repository;

        public CreateIncidentCommandHandler(IIncidentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IncidentDto> Handle(CreateIncidentCommand request, CancellationToken cancellationToken)
        {
            var incident = new Incident
            {
                Title = request.Title,
                Description = request.Description,
                Status = IncidentStatus.Open,
                CreatedDate = DateTime.UtcNow
            } ;
            var createdIncident = await _repository.AddAsync(incident, cancellationToken);
            return new IncidentDto(
            createdIncident.Id,
            createdIncident.Title,
            createdIncident.Description,
            createdIncident.Status.ToString(),
            createdIncident.CreatedDate);
        }
    }
}
