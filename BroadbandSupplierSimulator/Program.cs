using BroadbandSupplierSimulator.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<BroadbandSupplierSimulator.Simulation.SimulationOptions>(builder.Configuration.GetSection(BroadbandSupplierSimulator.Simulation.SimulationOptions.SectionName));
builder.Services.AddSingleton<BroadbandSupplierSimulator.Simulation.ISimulationHelper, BroadbandSupplierSimulator.Simulation.SimulationHelper>();
builder.Services.AddSingleton<BroadbandSupplierSimulator.Services.IAppointmentService, BroadbandSupplierSimulator.Services.AppointmentService>();
builder.Services.AddSingleton<BroadbandSupplierSimulator.Services.IGeographicAddressService, BroadbandSupplierSimulator.Services.GeographicAddressService>();
builder.Services.AddSimulatorData(builder.Configuration.GetConnectionString("Hobby") ?? throw new InvalidOperationException("Connection string 'Hobby' is not configured."));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
