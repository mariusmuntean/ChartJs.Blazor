using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ChartJs.Blazor.Sample.Serverside.Components;
using Sotsera.Blazor.Toaster.Core.Models;

namespace ChartJs.Blazor.Sample.Serverside
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddNewtonsoftJson();

            services.AddRazorComponents();

            services.AddToaster(config =>
            {
                config.PositionClass = Defaults.Classes.Position.TopRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Add the JS interop file to the webRooPath - make sure to reference it from index.cshtml
            ChartJsBlazor.AddStaticResourcesToWebRootPath(env.WebRootPath);


            app.UseRouting(routes =>
            {
                routes.MapRazorPages();
                routes.MapComponentHub<App>("app");
            });
        }
    }
}