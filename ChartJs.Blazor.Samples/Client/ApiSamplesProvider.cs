using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ChartJs.Blazor.Samples.Shared;

namespace ChartJs.Blazor.Samples.Client
{
    /// <summary>
    /// Reads the samples from the json file located in the
    /// WebRoot by fetching it from the server.
    /// </summary>
    public class ApiSamplesProvider : ISamplesProvider
    {
        private readonly HttpClient _httpClient;

        public ApiSamplesProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<SampleCategory>> GetSamples()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<SampleCategory>>(SamplesProvider.SamplesFileName);
        }
    }
}
