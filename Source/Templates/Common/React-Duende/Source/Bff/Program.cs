using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
	{
		options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
		options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
		options.DefaultSignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
	})
	.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
	{
		options.Cookie.Name = "__Host-Cookie";
		options.Cookie.SameSite = SameSiteMode.Strict;
	})
	.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
	{
		options.Authority = "https://demo.duendesoftware.com";
		options.ClientId = "interactive.confidential";
		options.ClientSecret = "secret";
		options.GetClaimsFromUserInfoEndpoint = true;
		options.MapInboundClaims = false;
		options.ResponseMode = "query";
		options.ResponseType = "code";
		options.SaveTokens = true;
		options.Scope.Clear();
		options.Scope.Add("api");
		options.Scope.Add("email");
		options.Scope.Add("offline_access");
		options.Scope.Add("openid");
		options.Scope.Add("profile");
	});
builder.Services.AddBff();
builder.Services.AddControllers();

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

if(builder.Environment.IsProduction())
	app.UseForwardedHeaders();

app.UseDefaultFiles(); // Maybe we do not need this.
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseBff();
app.UseAuthorization();
app.MapBffManagementEndpoints();
app.MapControllers()
	//.RequireAuthorization()
	.AsBffApiEndpoint();
app.MapFallbackToFile("index.html");

app.Run();