using FinancialInvestigationCopilotData.Entities;
using FinancialInvetigationApp.AI;
using FinancialInvetigationApp.AI.Models;
using FinancialInvetigationApp.Common.Exceptions;
using FinancialInvetigationApp.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvetigationApp.Features.Incidents.Commands.AnalyzeIncident
{
    public class AnalyzeIncidentCommandHandler : IRequestHandler<AnalyzeIncidentCommand, IncidentAnalysis>
    {
        private readonly IAIService _aiService;
        private readonly IIncidentRepository _incidentRepository;
        public AnalyzeIncidentCommandHandler(IAIService aIService, IIncidentRepository incidentRepository)
        {
            _aiService = aIService;
            _incidentRepository = incidentRepository;
        }
        public async Task<IncidentAnalysis> Handle(AnalyzeIncidentCommand request, CancellationToken cancellationToken)
        {
            var incident =
            await _incidentRepository.GetByIdAsync(
                request.IncidentId,
                cancellationToken);

            if (incident is null)
            {
                throw new NotFoundExceptions(
                    nameof(Incident),
                    request.IncidentId);
            }

            return await _aiService.AnalyzeAsync(
                incident.Title,
                incident.Description,
                cancellationToken);
        }
    }
}
