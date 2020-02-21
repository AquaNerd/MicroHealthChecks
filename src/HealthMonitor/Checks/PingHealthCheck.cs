using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthMonitor.Checks
{
    public class PingHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = await ping.SendPingAsync("www.google.com");
                    if (reply.Status != IPStatus.Success)
                    {
                        return HealthCheckResult.Unhealthy();
                    }

                    if (reply.RoundtripTime > 100)
                    {
                        return HealthCheckResult.Degraded();
                    }

                    return HealthCheckResult.Healthy();
                }
            }
            catch
            {
                return HealthCheckResult.Unhealthy();
            }
        }
    }
}