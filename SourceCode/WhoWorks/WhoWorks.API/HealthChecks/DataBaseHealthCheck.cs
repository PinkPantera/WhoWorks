using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WhoWorks.API.HealthChecks
{
    public class DataBaseHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, 
            CancellationToken cancellationToken = default)
        {
            bool isHealthy = await IsDatabaseConnectionOkAsync();
           return isHealthy ?
                    HealthCheckResult.Healthy("Database Connection is Ok") :
                    HealthCheckResult.Unhealthy("Database Connection ERROR");
        }

        private Task<bool> IsDatabaseConnectionOkAsync()
        {
            return Task.FromResult(true);
        }
    }
}
