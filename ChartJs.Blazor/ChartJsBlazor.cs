using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ChartJs.Blazor
{
    public static class ChartJsBlazor
    {
        private const string InteropFileName = "ChartJsInterop.js";
        private const string CSSFileName = "ChartJSBlazor.css";
        private const string WebRootSubfolderName = "ChartJs.Blazor";

        public static void AddStaticResourcesToWebRootPath(string webRootPath)
        {
            // Add js-interop file
            AddStaticResourcesToWebRootPath(webRootPath, InteropFileName, WebRootSubfolderName);
            
            // Add CSS file for chart-container (enables responsiveness)
            AddStaticResourcesToWebRootPath(webRootPath, CSSFileName, WebRootSubfolderName);
        }

        private static void AddStaticResourcesToWebRootPath(string webRootPath, string fileName, string subFolderName)
        {
            // Get File
            var chartJsAssembly = Assembly.GetExecutingAssembly();
            var chartJsInteropResourceName = chartJsAssembly.GetManifestResourceNames().FirstOrDefault(s => s.EndsWith(fileName));

            // Read the content of the file
            var resContent = string.Empty;
            using (var resourceStream = chartJsAssembly.GetManifestResourceStream(chartJsInteropResourceName))
            {
                if (resourceStream == null)
                {
                    throw new Exception($"Couldn't find the resource '{fileName}' in the assembly.");
                }

                using (var resStreamReader = new StreamReader(resourceStream))
                {
                    resContent = resStreamReader.ReadToEnd();
                }
            }

            // Get destination path and ensure the subdirectory exists
            var destinationFolderPath = Path.Combine(webRootPath, subFolderName);
            if (!Directory.Exists(destinationFolderPath))
            {
                Directory.CreateDirectory(destinationFolderPath);
            }

            // Write new file with that content to the wwwroot folder
            var destinationFilepath = Path.Combine(destinationFolderPath, fileName);
            File.WriteAllText(destinationFilepath, resContent);
        }
    }
}
