using FinancialInvestigatorInfra.Persistence;
using FinancialInvetigationApp.Features.Incidents.Commands.CreateIncident;
using FinancialInvetigationApp.Interfaces;
using FinancialInvetigationApp.IServices;
using FinancialInvetigationApp.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IInvestigationService, InvestigationService>();
builder.Services.AddSingleton<IIncidentRepository, InMemoryIncidentRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(
        Assembly.Load("FinancialInvetigationApp")));
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(
        typeof(CreateIncidentCommand).Assembly);
});
builder.Services.AddCors(options => { options.AddPolicy("DevCors", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("DevCors");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();