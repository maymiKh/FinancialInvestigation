namespace FinancialInvetigationApp.Features.Incidents.Querries.GetIncidentById
{
    public class GetIncidentByIdQueryHandler
    {
        public string Handle(
                GetIncidentByIdQuery query)
        {
            return $"Incident {query.Id}";
        }
    }
}
