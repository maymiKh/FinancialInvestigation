using FinancialInvetigationApp.AI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvetigationApp.AI
{
    public interface IAIService
    {
        Task<IncidentAnalysis> AnalyzeAsync(string title, string? description, CancellationToken cancellationToken);
    }
}
