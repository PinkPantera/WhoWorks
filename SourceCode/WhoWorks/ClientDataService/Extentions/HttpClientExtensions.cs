using System.Net.Http.Json;
using System.Text.Json;

namespace ClientDataService.Extentions
{
    public static class HttpClientExtensions
    {
        public static async Task<T?> GetAsync<T>(this HttpClient httpClient, string uri)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<T>(uri);
            }
            catch (HttpRequestException) // Non success
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }

            return default;
        }
    }
}
