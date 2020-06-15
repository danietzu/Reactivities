using Blazored.Toast;
using Client.Api;
using Client.Stores;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:4001")
            });
            builder.Services.AddScoped<Agent>();
            builder.Services.AddSingleton<RootStore>();
            builder.Services.AddBlazoredToast();

            await builder.Build().RunAsync();
        }
    }
}