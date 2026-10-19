using FinancialInvestigationCopilotData.Entities;
using FinancialInvetigationApp.Interfaces;
using System.ComponentModel;

namespace FinancialInvestigatorInfra.Persistence
{
    public class InMemoryIncidentRepository : IIncidentRepository
    {
        private readonly List<Incident> _incidents = [];
        private int _nextId = 1;
        public Task<Incident> AddAsync(Incident incident, CancellationToken cancellationToken)
        {
            incident.Id = _nextId++;
            _incidents.Add(incident);
            return Task.FromResult(incident);
        }
        public Task<IReadOnlyCollection<Incident>> GetAllAsync(CancellationToken cancellationToken)
        {
            IReadOnlyCollection<Incident> result = _incidents.ToList();
            return Task.FromResult(result);
        }
        public Task<Incident?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var incident = _incidents.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(incident);
        }

        public Task<Incident?> GetForUpdateAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangeAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
