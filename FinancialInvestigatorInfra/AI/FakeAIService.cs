using FinancialInvetigationApp.AI;
using FinancialInvetigationApp.AI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvestigatorInfra.AI
{
    public class FakeAIService : IAIService
    {
        public Task<IncidentAnalysis> AnalyzeAsync(string title, string? description, CancellationToken cancellationToken)
        {
            var result = new IncidentAnalysis(
            Summary:
                $"Analysis of {title}",
            PossibleCauses:
            [
                "Possible configuration issue",
                "Missing processing information"
            ],
            InvestigationSteps:
            [
                "Check application logs",
                "Verify configuration",
                "Review related processing data"
            ]);

            return Task.FromResult(result);
        }
    }
}
