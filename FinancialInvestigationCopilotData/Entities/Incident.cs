using FinancialInvestigationCopilotData.Enum;

namespace FinancialInvestigationCopilotData.Entities
{
    public class Incident
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public IncidentStatus Status { get; set; }
    }
}
