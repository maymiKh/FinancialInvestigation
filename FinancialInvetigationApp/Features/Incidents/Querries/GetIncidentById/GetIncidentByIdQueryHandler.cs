using FinancialInvestigationCopilotData.Entities;
using FinancialInvetigationApp.Common.Exceptions;
using FinancialInvetigationApp.DTOs;
using FinancialInvetigationApp.Interfaces;
using MediatR;

namespace FinancialInvetigationApp.Features.Incidents.Querries.GetIncidentById
{
    public class GetIncidentByIdQueryHandler : IRequestHandler<GetIncidentByIdQuery, IncidentDto>
    {
        private readonly IIncidentRepository _repository;

        public GetIncidentByIdQueryHandler(IIncidentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IncidentDto> Handle(GetIncidentByIdQuery request, CancellationToken cancellationToken)
        {
            var incident = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (incident is null)
            {
                throw new NotFoundExceptions(nameof(Incident), request.Id);
            }
            return new IncidentDto(
            incident.Id,
            incident.Title,
            incident.Description,
            incident.Status.ToString(),
            incident.CreatedDate
            );
        }
    }
}
