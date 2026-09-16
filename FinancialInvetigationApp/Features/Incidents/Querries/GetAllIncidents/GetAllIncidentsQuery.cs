using FinancialInvetigationApp.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvetigationApp.Features.Incidents.Querries.GetAllIncidents
{
    public record GetAllIncidentQuery() : IRequest<IReadOnlyCollection<IncidentDto>>;
}
