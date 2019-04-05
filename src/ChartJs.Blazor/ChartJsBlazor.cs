using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ChartJs.Blazor
{
    public static class ChartJsBlazor
    {
        private const string InteropFileName = "ChartJsInterop.js";
        private const string WebRootSubfolderName = "ChartJs.Blazor";

        public static void AddStaticResourcesToWebRootPath(string webRootPath)
        {
            // Get the content of ChartJsInterop.js
            var chartJsAssembly = Assembly.GetCallingAssembly();
            var chartJsInteropResourceName = chartJsAssembly.GetManifestResourceNames().FirstOrDefault(s => s.EndsWith(InteropFileName));
            var resContent = string.Empty;
            using (var resourceStream = chartJsAssembly.GetManifestResourceStream(chartJsInteropResourceName))
            {
                if (resourceStream == null)
                {
                    throw new Exception($"Couldn't find the resource '{InteropFileName}' in the assembly");
                }

                using (var resStreamReader = new StreamReader(resourceStream))
                {
                    resContent = resStreamReader.ReadToEnd();
                }
            }

            // Add it to the wwwroot folder
            var destinationFolderPath = Path.Combine(webRootPath, WebRootSubfolderName);
            if (!Directory.Exists(destinationFolderPath))
            {
                Directory.CreateDirectory(destinationFolderPath);
            }

            var destinationFilepath = Path.Combine(destinationFolderPath, InteropFileName);
            File.WriteAllText(destinationFilepath, resContent);
        }

    }
}
