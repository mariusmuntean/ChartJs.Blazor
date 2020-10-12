using System;
using Microsoft.AspNetCore.Components;
using System.Web;
using System.Collections.Specialized;

namespace ChartJs.Blazor.Samples.Shared
{
    public class DualModeSerivce
    {
        public const string ModeQueryKey = "mode";
        public const string ModeQueryValue = "server";

        public DualModeSerivce(bool serverMode)
        {
            ServerMode = serverMode;
        }

        public bool ServerMode { get; }

        /// <summary>
        /// Switch the <see cref="ServerMode"/> by reloading the page with
        /// adjusted query parameters.
        /// </summary>
        /// <param name="navigationManager">A scoped <see cref="NavigationManager"/> (workaround).</param>
        public void SwitchMode(NavigationManager navigationManager)
        {
            // This throws a System.InvalidOperationException: 'RemoteNavigationManager' has not been initialized.
            // I've not found a way of solving this and none of the issues I found helped
            // - https://github.com/dotnet/aspnetcore/issues/13582
            // - https://github.com/dotnet/aspnetcore/issues/13906
            // - https://github.com/dotnet/aspnetcore/issues/11867
            // - https://stackoverflow.com/questions/61344858/blazor-system-invalidoperationexception-remotenavigationmanager-has-not-bee
            //using IServiceScope scope = _scopeFactory.CreateScope();
            //NavigationManager navigationManager = scope.ServiceProvider.GetRequiredService<NavigationManager>();

            Uri uri = new Uri(navigationManager.Uri);
            NameValueCollection qs = HttpUtility.ParseQueryString(uri.Query);
            if (ServerMode)
            {
                qs.Remove(ModeQueryKey);
            }
            else
            {
                qs.Set(ModeQueryKey, ModeQueryValue);
            }

            UriBuilder uriBuilder = new UriBuilder(uri);
            uriBuilder.Query = qs.ToString();

            navigationManager.NavigateTo(uriBuilder.Uri.ToString(), forceLoad: true);
        }
    }
}
