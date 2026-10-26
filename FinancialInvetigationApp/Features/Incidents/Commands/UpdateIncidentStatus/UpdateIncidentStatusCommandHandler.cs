using FinancialInvestigationCopilotData.Enum;
using FinancialInvetigationApp.Common.Exceptions;
using FinancialInvetigationApp.DTOs;
using FinancialInvetigationApp.Interfaces;
using MediatR;

namespace FinancialInvetigationApp.Features.Incidents.Commands.UpdateIncidentStatus
{
    public class UpdateIncidentStatusCommandHandler : IRequestHandler<UpdateIncidentStatusCommand, IncidentDto>
    {
        private readonly IIncidentRepository _incidentRepository;
        public UpdateIncidentStatusCommandHandler(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<IncidentDto> Handle(UpdateIncidentStatusCommand request, CancellationToken cancellationToken)
        {
            var incident = await _incidentRepository.GetForUpdateAsync(
            request.Id,
            cancellationToken);

            if (incident is null)
            {
                throw new NotFoundExceptions(nameof(incident), request.Id);
            }

            var statusWasParsed = Enum.TryParse<IncidentStatus>(
                request.Status,
                ignoreCase: true,
                out var newStatus);

            if (!statusWasParsed)
            {
                throw new ArgumentException(
                    $"Invalid incident status: {request.Status}");
            }

            incident.Status = newStatus;

            await _incidentRepository.SaveChangeAsync(
                cancellationToken);

            return new IncidentDto(
                incident.Id,
                incident.Title,
                incident.Description,
                incident.Status.ToString(),
                incident.CreatedDate);
        }
    }
}
