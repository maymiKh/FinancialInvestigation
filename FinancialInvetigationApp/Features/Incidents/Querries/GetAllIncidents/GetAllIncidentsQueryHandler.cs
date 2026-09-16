using FinancialInvetigationApp.DTOs;
using FinancialInvetigationApp.Interfaces;
using MediatR;

namespace FinancialInvetigationApp.Features.Incidents.Querries.GetAllIncidents
{
    public class GetAllIncidentsQueryHandler : IRequestHandler<GetAllIncidentQuery, IReadOnlyCollection<IncidentDto>>
    {
        private readonly IIncidentRepository _repository;

        public GetAllIncidentsQueryHandler(IIncidentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyCollection<IncidentDto>> Handle(GetAllIncidentQuery request, CancellationToken cancellationToken)
        {
            var incidents = await _repository.GetAllAsync(cancellationToken);
            return incidents.Select(incident => new IncidentDto(
                incident.Id,
                incident.Title,
                incident.Description,
                incident.Status.ToString(),
                incident.CreatedDate
            )).ToList();
        }
    }
}
