using FinancialInvestigationCopilotData.Entities;
using FinancialInvetigationApp.Common.Exceptions;
using FinancialInvetigationApp.Interfaces;
using MediatR;

namespace FinancialInvetigationApp.Features.Incidents.Commands.DeleteIncident
{
    public class DeleteIncidentCommandHandler : IRequestHandler<DeleteIncidentCommand>
    {
        private readonly IIncidentRepository _incidentRepository;
        public DeleteIncidentCommandHandler(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }
        public async Task Handle(DeleteIncidentCommand request, CancellationToken cancellationToken)
        {
            var existingIncident = await _incidentRepository.GetForUpdateAsync(request.id, cancellationToken);

            if(existingIncident != null){
                _incidentRepository.DeleteIncident(existingIncident);
                await _incidentRepository.SaveChangeAsync(cancellationToken);
            }
            throw new NotFoundExceptions(nameof(Incident), request.id);
        }
    }
}
