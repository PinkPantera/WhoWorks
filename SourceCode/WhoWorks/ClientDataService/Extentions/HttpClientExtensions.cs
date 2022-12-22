using System.Net.Http.Json;
using System.Text.Json;

namespace ClientDataService.Extentions
{
    public static class HttpClientExtensions
    {
        public static async Task<T?> GetAsync<T>(this HttpClient httpClient, string uri)
        {
            return await httpClient.GetFromJsonAsync<T>(uri);
        }
    }
}
