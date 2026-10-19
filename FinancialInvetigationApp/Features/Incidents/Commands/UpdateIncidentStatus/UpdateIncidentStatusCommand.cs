using FinancialInvetigationApp.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvetigationApp.Features.Incidents.Commands.UpdateIncidentStatus
{
    public record UpdateIncidentStatusCommand
    (
        int Id,
        string Status
    ) : IRequest<IncidentDto>;
}
