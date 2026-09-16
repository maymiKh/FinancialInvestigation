using FinancialInvestigationCopilotData.Entities;

namespace FinancialInvetigationApp.Interfaces
{
    public interface IIncidentRepository
    {
        Task<Incident?> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<Incident> AddAsync(Incident incident, CancellationToken cancellationToken);

        Task<IReadOnlyCollection<Incident>> GetAllAsync(CancellationToken cancellationToken);
    }
}
