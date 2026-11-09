using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvetigationApp.AI.Models
{
    public record IncidentAnalysis(
    string Summary,
    IReadOnlyCollection<string> PossibleCauses,
    IReadOnlyCollection<string> InvestigationSteps);
}
