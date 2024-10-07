using Microsoft.Extensions.Hosting;
using StarterMicroservice.AppHost;

// Note that this is setting up the ORCHESTRATION
// If we have external resources already provisioned
// (ie for Prod env) we need to point the AppHost
// to those resources, otherwise it will provision
// them locally as containers
var builder = DistributedApplication.CreateBuilder(args);

// Add secrets from Azure KeyVault
/* Uncomment when AzureKeyVault is provisioned
builder.Configuration.AddAzureKeyVaultSecrets("AzureKeyVault");
*/

// We need to bind the secrets to the correct
// configuration section depending on Environment
if (builder.Environment.IsProduction())
{
    builder.BindProductionSecrets();
}
else
{
    builder.BindDevelopmentSecrets();
}

// Add our postgresql database to management
// Prod connects remotely to a resource
// while Dev creates a local container
// It is also possible to specify the exact image to use:
// .WithImage
// .WithImageTag
var mySql = (builder.Environment.IsProduction()) switch
{
    true  => builder.AddConnectionString("StarterDb"),
    false => builder.AddMySql("MyServer")
};

// This is not actually creating a database
// It is creating a CONNECTION STRING for a database
// The provisioning is still required to happen before runtime
// We accomplish this by using EF Core migrations at startup
var starterDb = (mySql is IResourceBuilder<MySqlServerResource> server)
    ? server.AddDatabase("StarterDb")
    : mySql;

// Add projects to Aspire management
// with references to the resources
builder.AddProject<Projects.StarterMicroservice_API>("starter-api")
    .WithReference(starterDb);

builder.Build().Run();