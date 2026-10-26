using FinancialInvestigationCopilotApi.Middelware;
using FinancialInvestigatorInfra.Persistence;
using FinancialInvetigationApp.Common.Behaviors;
using FinancialInvetigationApp.Features.Incidents.Commands.CreateIncident;
using FinancialInvetigationApp.Features.Incidents.Commands.UpdateIncidentStatus;
using FinancialInvetigationApp.Interfaces;
using FinancialInvetigationApp.IServices;
using FinancialInvetigationApp.Services;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IInvestigationService, InvestigationService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IIncidentRepository,IncidentRepository>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(
        typeof(CreateIncidentCommand).Assembly);
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateIncidentCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateIncidentStatusCommandHandler>();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));

builder.Services.AddCors(options => { options.AddPolicy("DevCors", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });
var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("DevCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();