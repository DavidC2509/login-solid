using Projects;
using Template.AppHost.Extensions;

var builder = DistributedApplication.CreateBuilder(args);

#region Postbres Db

var serverPotgsres = builder.AddPostgres("login-solid-server").WithDataVolume().WithPgAdmin(c => c.WithHostPort(5050));

var postgresDbNext = builder.ExecutionContext.IsRunMode ? serverPotgsres
    .AddDatabase("login-solid-database") : builder.AddConnectionString("login-solid-database");

#endregion

#region Login Solid
builder.AddProject<TemplateMigrate>("login-solid-migration")
    .WithReference(postgresDbNext).WaitFor(postgresDbNext);

var api = builder.AddProject<Api>("login-solid")
        .WithReference(postgresDbNext);

#endregion



builder.Build().Run();
