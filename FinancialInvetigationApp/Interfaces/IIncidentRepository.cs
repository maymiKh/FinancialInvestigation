using FinancialInvestigationCopilotData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvetigationApp.Interfaces
{
    public interface IIncidentRepository
    {
        public interface IIncidentRepository
        {
            Task<Incident?> GetByIdAsync(int id);

            Task AddAsync(Incident incident);
        }
    }
}
