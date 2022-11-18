using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientDataService.Extentions
{
    public static class HttpClientExtensions
    {
        public static async Task<List<T>> GetAsyncM<T>(this HttpClient httpClient, string uri)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<T>>(uri);
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

            return null;
        }
    }
}
