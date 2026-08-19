using FinancialInvetigationApp.DTOs;
using MediatR;

namespace FinancialInvetigationApp.Features.Incidents.Querries.GetIncidentById
{
    public class GetIncidentByIdQueryHandler : IRequestHandler<GetIncidentByIdQuery, IncidentDto>
    {
        public async Task<IncidentDto> Handle(GetIncidentByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(
                new IncidentDto(
                request.Id,
                "Payment Issue",
                "Payment generation failed",
                "Open"));
        }
    }
}
