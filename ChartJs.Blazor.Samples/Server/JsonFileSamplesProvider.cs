using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ChartJs.Blazor.Samples.Shared;
using Microsoft.AspNetCore.Hosting;

namespace ChartJs.Blazor.Samples.Server
{
    /// <summary>
    /// Reads the samples from the json file located in the
    /// WebRoot directly on the server.
    /// </summary>
    public class JsonFileSamplesProvider : ISamplesProvider
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public JsonFileSamplesProvider(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IEnumerable<SampleCategory>> GetSamples()
        {
            string path = Path.Combine(_hostEnvironment.WebRootPath, SamplesProvider.SamplesFileName);
            using FileStream file = File.OpenRead(path);

            // Cannot return the Task directly because then the file
            // will be closed once the deserialization actually takes place
            return await JsonSerializer.DeserializeAsync<IEnumerable<SampleCategory>>(file);
        }
    }
}
