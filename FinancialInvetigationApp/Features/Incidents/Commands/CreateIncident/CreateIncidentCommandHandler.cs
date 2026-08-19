using MediatR;

namespace FinancialInvetigationApp.Features.Incidents.Commands.CreateIncident
{
    public class CreateIncidentCommandHandler : IRequestHandler<CreateIncidentCommand, string>
    {
        public async Task<string> Handle(CreateIncidentCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult($"Incident'{request.Title}' created");
        }
    }
}
