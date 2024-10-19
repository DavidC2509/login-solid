using Projects;
using Template.AppHost.Extensions;

var builder = DistributedApplication.CreateBuilder(args);

#region Postbres Db

var serverPotgsres = builder.AddPostgres("next-database-server",
    password: builder.AddParameter("PostgresPassword", secret: true)).WithDataVolume().WithPgAdmin(c => c.WithHostPort(5050));

var postgresDbNext = builder.ExecutionContext.IsRunMode ? serverPotgsres
    .AddDatabase("login-solid") : builder.AddConnectionString("login-solid");

#endregion

#region Next Project
builder.AddProject<TemplateMigrate>("next-database-migration")
    .WithReference(postgresDbNext).WaitFor(postgresDbNext);

var api = builder.AddProject<Api>("nextwebapi")
        .WithReference(postgresDbNext);

#endregion



builder.Build().Run();
