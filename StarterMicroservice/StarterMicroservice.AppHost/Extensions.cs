namespace StarterMicroservice.AppHost
{
    internal static class Extensions
    {
        public static void BindProductionSecrets(this IDistributedApplicationBuilder builder)
        {
            var connectionStrings = builder.Configuration.GetSection("ConnectionStrings");
            foreach (var secret in connectionStrings.GetChildren())
            {
                if (secret.Key is not "AzureKeyVault")
                    secret.Value = builder.Configuration[secret.Key];
            }
        }

        public static void BindDevelopmentSecrets(this IDistributedApplicationBuilder builder)
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
