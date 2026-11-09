using FinancialInvetigationApp.AI.Models;
using MediatR;

namespace FinancialInvetigationApp.Features.Incidents.Commands.AnalyzeIncident
{
    public record AnalyzeIncidentCommand(int IncidentId): IRequest<IncidentAnalysis>;
    
}
