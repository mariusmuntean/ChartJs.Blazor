using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ChartJs.Blazor.Sample.ClientSide
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddNewtonsoftJson();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
