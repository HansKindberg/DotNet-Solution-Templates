using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shared.Net.Http;
using Spa;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient(HttpClientFactoryNames.Api, client => client.BaseAddress = new Uri(builder.Configuration["Api:BaseAddress"]!));
builder.Services.AddHttpClient(HttpClientFactoryNames.Bff, client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

await builder.Build().RunAsync();