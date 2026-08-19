using FinancialInvetigationApp.DTOs;
using MediatR;

namespace FinancialInvetigationApp.Features.Incidents.Querries.GetIncidentById
{
    public record GetIncidentByIdQuery(int Id) : IRequest<IncidentDto>;
}
