using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Mime;
using System.Text.Json;
using WhoWorks.Core.Diagnostic;

namespace WhoWorks.API.HealthChecks
{
    public static class HealthCheckHelper
    {
        public static Task WriteResponse(HttpContext httpContext, HealthReport healthReport)
        {
            string json = JsonSerializer.Serialize(
                new ServerHealthInformation
                (
                    healthReport.Status.ToString(),
                    healthReport.TotalDuration,
                    healthReport.Entries
                    .Select(e =>
                        new HealthReportItem
                        (
                            e.Key.ToString(),
                            e.Value.Description,
                            e.Value.Duration,
                            Enum.GetName(typeof(HealthStatus), e.Value.Status),
                            e.Value.Exception?.Message,
                            e.Value.Data
                        ))
                    .ToList()
                ));
            httpContext.Response.ContentType = MediaTypeNames.Application.Json;

            return httpContext.Response.WriteAsync(json);
        }
    }
}
