namespace FinancialInvetigationApp.Features.Incidents.Commands.CreateIncident
{
    public class CreateIncidentCommandHandler
    {
        public string Handle(CreateIncidentCommand command)
        {
            return $"Incident'{command.Title}' created";
        }
    }
}
