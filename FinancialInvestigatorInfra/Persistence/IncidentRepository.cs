using FinancialInvestigationCopilotData.Entities;
using FinancialInvetigationApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialInvestigatorInfra.Persistence
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly AppDbContext _context;

        public IncidentRepository (AppDbContext context)
        {
            _context = context;
        }
        public async Task<Incident> AddAsync(Incident incident, CancellationToken cancellationToken)
        {
            await _context.Incidents.AddAsync(
            incident,
            cancellationToken);

            await _context.SaveChangesAsync(
                cancellationToken);

            return incident;
        }

        public void DeleteIncident(Incident incident)
        {
            _context.Incidents.Remove(incident);
        }

        public async Task<IReadOnlyCollection<Incident>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Incidents
             .AsNoTracking()
             .OrderByDescending(incident => incident.CreatedDate)
             .ToListAsync(cancellationToken);
        }

        public async Task<Incident?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Incidents
            .AsNoTracking()
            .FirstOrDefaultAsync(
                incident => incident.Id == id,
                cancellationToken);
        }

        public async Task<Incident?> GetForUpdateAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Incidents
            .FirstOrDefaultAsync(
                incident => incident.Id == id,
                cancellationToken);
        }

        public async Task SaveChangeAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
