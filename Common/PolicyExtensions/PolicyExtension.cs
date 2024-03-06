using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Common.PolicyExtensions;
public static class PolicyExtensions
{
    public static void GetPolicyForCors(this CorsPolicyBuilder policy, int portNumber)
    {
        policy
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS")
            .SetPreflightMaxAge(TimeSpan.FromSeconds(3600))
            .WithOrigins(
                "http://localhost:4200",
                $"http://localhost:{portNumber}"
            );
    }
}