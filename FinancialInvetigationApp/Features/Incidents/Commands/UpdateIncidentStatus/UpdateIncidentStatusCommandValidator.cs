using FinancialInvestigationCopilotData.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvetigationApp.Features.Incidents.Commands.UpdateIncidentStatus
{
    public class UpdateIncidentStatusCommandValidator : AbstractValidator<UpdateIncidentStatusCommand>
    {
        public UpdateIncidentStatusCommandValidator()
        {
            RuleFor(command => command.Id)
            .GreaterThan(0)
            .WithMessage(
                "The incident ID must be greater than zero.");

            RuleFor(command => command.Status)
                .NotEmpty()
                .WithMessage(
                    "The incident status is required.");

            RuleFor(command => command.Status)
                .Must(BeAValidStatus)
                .WithMessage(
                    "Status must be Open, InProgress, Resolved, or Closed.");
        }

        private static bool BeAValidStatus(string status)
        {
            return Enum.TryParse<IncidentStatus>(
                status,
                ignoreCase: true,
                out _);
        }
    }
}
