using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvetigationApp.DTOs
{
    public record IncidentDto(
        int Id,
        string Title,
        string Description,
        string Status
        );
}
