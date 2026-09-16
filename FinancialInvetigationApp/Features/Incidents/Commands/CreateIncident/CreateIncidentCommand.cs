using FinancialInvetigationApp.DTOs;
using MediatR;

namespace FinancialInvetigationApp.Features.Incidents.Commands.CreateIncident
{
    public record CreateIncidentCommand
    (
        string Title,
        string Description
    ) : IRequest<IncidentDto>;
}
