using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvetigationApp.Features.Incidents.Commands.CreateIncident
{
    public class CreateIncidentCommandValidator : AbstractValidator<CreateIncidentCommand>
    {
        public CreateIncidentCommandValidator()
        {
            RuleFor(command => command.Title).NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(command => command.Title)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage(
                    "The incident title cannot exceed 200 characters.");

            RuleFor(command => command.Description)
                .MaximumLength(2000)
                .WithMessage(
                    "The incident description cannot exceed 2000 characters.");
        }
    }
}
