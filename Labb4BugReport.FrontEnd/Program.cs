using System;
using System.Net.Http;
using System.Threading.Tasks;
using Labb4BugReport.FrontEnd.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Labb4BugReport.FrontEnd
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(
                sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetConnectionString("apiUrl")) });
            
            builder.Services
                .AddScoped<ILocalStorageService, LocalStorageService>()
                .AddScoped<IBugReportService, BugReportService>()
                .AddScoped<ICommentService, CommentService>()
                .AddScoped<IHttpService, HttpService>();
            await builder.Build().RunAsync();
        }
    }
}