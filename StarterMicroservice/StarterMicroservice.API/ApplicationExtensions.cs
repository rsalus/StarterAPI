using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.OpenApi.Models;

namespace StarterMicroservice.API
{
    internal static class ApplicationExtensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            // Configuration
            builder.Configuration
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            // Load in Secrets from Azure
            /* Uncomment this after provisioning AzureKeyVault
            builder.Configuration.AddAzureKeyVault(
                new SecretClient(
                    new Uri($"https://{builder.Configuration["Azure:AzureKeyVault"]}.vault.azure.net/"),
                    new DefaultAzureCredential()
                ),
                new KeyVaultSecretManager()
            );
            */

            // Bind Secrets to appsettings depending on Env
            if (builder.Environment.IsProduction())
            {
                builder.BindProductionSecrets();
            }
            else
            {
                builder.BindDevelopmentSecrets();
            }

            // Options
            builder.Services.AddOptions();

            // Logging
            builder.Services.AddLogging();

            // Database
            builder.AddMySqlDbContext<MyUserContext>("StarterDb");

            // Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "StarterMicroservice API", Version = "v1" });
            });

            // Controllers and Endpoints
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            // Healthcheck configuration
            builder.Services.AddRequestTimeouts();
            builder.Services.AddOutputCache();

            // Memory Cache
            builder.Services.AddMemoryCache();
        }

        // Unfortunately we need these extension methods
        // to bind the values retrieved from Azure KeyVault
        // to the ConnectionStrings section of our appsettings
        private static void BindProductionSecrets(this IHostApplicationBuilder builder)
        {
            var connectionStrings = builder.Configuration.GetSection("ConnectionStrings");
            foreach (var secret in connectionStrings.GetChildren())
            {
                if (secret.Key is not "AzureKeyVault")
                    secret.Value = builder.Configuration[secret.Key];
            }
        }

        private static void BindDevelopmentSecrets(this IHostApplicationBuilder builder)
        {
            var connectionStrings = builder.Configuration.GetSection("ConnectionStrings");
            foreach (var secret in connectionStrings.GetChildren())
            {
                if (secret.Key is not "AzureKeyVault"
                    && secret.Key is not "StarterDb")
                {
                    secret.Value = builder.Configuration[secret.Key];
                }
            }
        }
    }
}
