using BroadbandSupplierSimulator.Data;
using BroadbandSupplierSimulator.Jobs;
using Hangfire;
using Hangfire.PostgreSql;
using BroadbandSupplierSimulator.Services;
using BroadbandSupplierSimulator.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<BroadbandSupplierSimulator.Simulation.SimulationOptions>(builder.Configuration.GetSection(BroadbandSupplierSimulator.Simulation.SimulationOptions.SectionName));
builder.Services.AddSingleton<BroadbandSupplierSimulator.Simulation.ISimulationHelper, BroadbandSupplierSimulator.Simulation.SimulationHelper>();
builder.Services.AddSingleton<BroadbandSupplierSimulator.Services.IAppointmentService, BroadbandSupplierSimulator.Services.AppointmentService>();
builder.Services.AddSingleton<BroadbandSupplierSimulator.Services.IGeographicAddressService, BroadbandSupplierSimulator.Services.GeographicAddressService>();
var connectionString = builder.Configuration.GetConnectionString("Hobby") ?? throw new InvalidOperationException("Connection string 'Hobby' is not configured.");
builder.Services.AddSimulatorData(connectionString);
builder.Services.AddHangfire(config => config
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UsePostgreSqlStorage(options => options.UseNpgsqlConnection(connectionString)));
builder.Services.AddHangfireServer();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IProcessProductOrderJob, ProcessProductOrderJob>();
builder.Services.AddSingleton<IOrderItemValidator, AddOrderItemValidator>();
builder.Services.AddSingleton<IOrderItemValidator, ModifyOrderItemValidator>();
builder.Services.AddSingleton<IOrderItemValidator, DeleteOrderItemValidator>();
builder.Services.AddSingleton<IOrderItemValidator, NoChangeOrderItemValidator>();
builder.Services.AddSingleton<IOrderItemValidatorFactory, OrderItemValidatorFactory>();
builder.Services.AddScoped<ICreateProductOrderService, CreateProductOrderService>();
builder.Services.AddSingleton<BroadbandSupplierSimulator.Mappers.IProductOrderCreateMapper, BroadbandSupplierSimulator.Mappers.ProductOrderCreateMapper>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseHangfireDashboard();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
