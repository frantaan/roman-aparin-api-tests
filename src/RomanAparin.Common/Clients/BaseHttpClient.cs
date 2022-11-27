using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RomanAparin.Common.Clients
{
    public interface IBaseHttpClient
    {
        Task<T> SendAsync<T>(HttpMethod method, string endpoint, object requestData, JsonSerializerOptions jsonOptions = null, CancellationToken token = default);
    }
    public class BaseHttpClient : IBaseHttpClient
    {
        private readonly HttpClient _httpClient;

        public BaseHttpClient(IOptions<TestServicesOptions> options)
        {
            HttpClientHandler clientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };
            clientHandler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            _httpClient = new HttpClient(clientHandler);
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
            _httpClient.Timeout = TimeSpan.FromSeconds(360);
        }
        public async Task<T> SendAsync<T>(HttpMethod method, string endpoint, object requestData, JsonSerializerOptions jsonOptions = null, CancellationToken token = default)
        {
            try
            {
                var fullEndpoint = _httpClient.BaseAddress + endpoint;
                var request = new HttpRequestMessage(method, fullEndpoint);
                request.Headers.Date = DateTimeOffset.Now;
                request.Headers.Host = _httpClient.BaseAddress.Host;
                if (method.Method.ToUpper() == "POST")
                {
                    var jsonContent = JsonSerializer.Serialize(requestData, requestData.GetType(), jsonOptions);
                    request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                }
                LogRequest(request);
                var requestResult = await _httpClient.SendAsync(request);
                LogResponse(requestResult);
                Console.WriteLine($"\n{requestResult.Headers}");
                var content = await requestResult.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content)!;
            }
            catch (Exception)
            { 
                return default(T)!;
            }
        }

        private void LogRequest(HttpRequestMessage request)
        {
            Console.WriteLine(request.RequestUri);
            foreach (var item in request.Headers)
            {
                Console.WriteLine($"{item.Key}: {item.Value.First()}");
            }
            Console.WriteLine(request.Content);
        }

        private void LogResponse(HttpResponseMessage response)
        {
            Console.WriteLine($"Status code {response.StatusCode}");
            foreach (var item in response.Headers)
            {
                Console.WriteLine($"{item.Key}: {item.Value.First()}");
            }
            Console.WriteLine($"Response: {response.Content.ReadAsStringAsync().Result}");
        }
    }
}
