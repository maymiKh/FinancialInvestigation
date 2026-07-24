using FinancialInvetigationApp.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvetigationApp.Services
{
    public class InvestigationService : IInvestigationService
    {
        public string AnalyzeIncident(string incident)
        {
            return $"Analysis for {incident}";
        }
    }
}
