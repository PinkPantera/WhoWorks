using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WhoWorks.Core.Diagnostic
{
    public static class ApiServerDiagnostic
    {
        public static async Task<ServerHealthInformation> GetServerHealthInformationAsync(string? requestUri,
            CancellationToken cancellationToken = default)
        {
            using var httpClient = new HttpClient();
            var taskResponse = await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            return await taskResponse.Content.ReadFromJsonAsync<ServerHealthInformation>();
        }
    }
}
