using Bff.Models.Configuration;
using Bff.Models.Web.Builder.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IConfigureOptions<MvcOptions>, ConfigureMvcOptions>();

builder.Services.Configure<BffOptions>(builder.Configuration.GetSection(ConfigurationKeys.BffPath));

if(builder.Environment.IsProduction())
{
	builder.Services.Configure<ForwardedHeadersOptions>(options =>
	{
		options.AllowedHosts.Clear();
		options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
		options.KnownNetworks.Clear();
		options.KnownProxies.Clear();
	});
}

var app = builder.Build();

if(builder.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseWebAssemblyDebugging();
}
else if(builder.Environment.IsProduction())
{
	app.UseExceptionHandler("/Error");
	app.UseForwardedHeaders();
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseBff();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();