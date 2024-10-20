
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Template.Api.Extensions;
using Template.Command;
using Template.Command.Database;
using Template.ServiceDefaults;
using Template.Services;

var builder = WebApplication.CreateBuilder(args);
var appName = "LoginSolid";

builder.AddServiceDefaults();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.ConfigureSwagger();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddProblemDetails();

builder.AddNpgsqlDbContext<DataBaseContext>("login-solid-database");

builder.Services.AddApplication();

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new DefaultInfrastructureModule(builder.Environment.EnvironmentName == "Development"));
});

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.UseHttpsRedirection();

try
{
    app.Logger.LogInformation("Starting web host ({ApplicationName})...", appName);
    app.Run();
}
catch (Exception ex)
{
    app.Logger.LogCritical(ex, "Host terminated unexpectedly ({ApplicationName})...", appName);
}
