using AspNetCore.Diagnostics.HealthChecks;

namespace HealthApi.Health {
    internal class RandomHealthCheck : IHealthCheck {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default) {
            try {
                var healthyNumber = new Random().Next(1, 4);

                switch (healthyNumber) {
                    case 1 :
                        return HealthCheckResult.Healthy("HealthApiService is Healthy!");
                    case 2 : 
                        return HealthCheckResult.Degraded("HealthApiService is partially Healthy!");
                    case 3 : 
                        return HealthCheckResult.Unhealthy("HealthApiService is UnHealthy!");
                    default:
                }
            } catch {
                return HealthCheckResult.Unhealthy($"Error when trying to check health for {nameof(RandomHealthCheck)}");
            }
        }
    }
}