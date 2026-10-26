using FinancialInvetigationApp.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvetigationApp.Features.Incidents.Commands.DeleteIncident
{
    public record DeleteIncidentCommand
    (
        int id
    ) : IRequest;
}
