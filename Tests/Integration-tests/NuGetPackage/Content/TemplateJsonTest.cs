using System.Text.Json;
using NuGet.Packaging;

namespace IntegrationTests.NuGetPackage.Content
{
	public class TemplateJsonTest
	{
		#region Methods

		/// <summary>
		/// Test to make sure the preparation of the template content has time to finish before the package is created.
		/// </summary>
		[Theory]
		[InlineData("AspNet-Razor-ExtraLarge", "HK-AspNet-Razor-ExtraLarge", "HK-AspNet-Razor-ExtraLarge", "hk-aspnet-razor-xl")]
		[InlineData("AspNet-Razor-Large", "HK-AspNet-Razor-Large", "HK-AspNet-Razor-Large", "hk-aspnet-razor-l")]
		[InlineData("AspNet-Razor-Medium", "HK-AspNet-Razor-Medium", "HK-AspNet-Razor-Medium", "hk-aspnet-razor-m")]
		[InlineData("AspNet-Razor-Small", "HK-AspNet-Razor-Small", "HK-AspNet-Razor-Small", "hk-aspnet-razor-s")]
		[InlineData("Blazor-Duende-ExtraLarge", "HK-Blazor-Duende-ExtraLarge", "HK-Blazor-Duende-ExtraLarge", "hk-blazor-duende-xl")]
		[InlineData("Blazor-Duende-Large", "HK-Blazor-Duende-Large", "HK-Blazor-Duende-Large", "hk-blazor-duende-l")]
		[InlineData("Blazor-Duende-Medium", "HK-Blazor-Duende-Medium", "HK-Blazor-Duende-Medium", "hk-blazor-duende-m")]
		[InlineData("Blazor-Duende-Small", "HK-Blazor-Duende-Small", "HK-Blazor-Duende-Small", "hk-blazor-duende-s")]
		[InlineData("Blazor-ExtraLarge", "HK-Blazor-ExtraLarge", "HK-Blazor-ExtraLarge", "hk-blazor-xl")]
		[InlineData("Blazor-Large", "HK-Blazor-Large", "HK-Blazor-Large", "hk-blazor-l")]
		[InlineData("Blazor-Medium", "HK-Blazor-Medium", "HK-Blazor-Medium", "hk-blazor-m")]
		[InlineData("Blazor-Small", "HK-Blazor-Small", "HK-Blazor-Small", "hk-blazor-s")]
		[InlineData("NuGet-Package-ExtraLarge", "HK-NuGet-Package-ExtraLarge", "HK-NuGet-Package-ExtraLarge", "hk-nuget-package-xl")]
		[InlineData("NuGet-Package-Large", "HK-NuGet-Package-Large", "HK-NuGet-Package-Large", "hk-nuget-package-l")]
		[InlineData("NuGet-Package-Medium", "HK-NuGet-Package-Medium", "HK-NuGet-Package-Medium", "hk-nuget-package-m")]
		[InlineData("NuGet-Package-Small", "HK-NuGet-Package-Small", "HK-NuGet-Package-Small", "hk-nuget-package-s")]
		[InlineData("React-Duende-ExtraLarge", "HK-React-Duende-ExtraLarge", "HK-React-Duende-ExtraLarge", "hk-react-duende-xl")]
		[InlineData("React-Duende-Large", "HK-React-Duende-Large", "HK-React-Duende-Large", "hk-react-duende-l")]
		[InlineData("React-Duende-Medium", "HK-React-Duende-Medium", "HK-React-Duende-Medium", "hk-react-duende-m")]
		[InlineData("React-Duende-Small", "HK-React-Duende-Small", "HK-React-Duende-Small", "hk-react-duende-s")]
		[InlineData("React-ExtraLarge", "HK-React-ExtraLarge", "HK-React-ExtraLarge", "hk-react-xl")]
		[InlineData("React-Large", "HK-React-Large", "HK-React-Large", "hk-react-l")]
		[InlineData("React-Medium", "HK-React-Medium", "HK-React-Medium", "hk-react-m")]
		[InlineData("React-Small", "HK-React-Small", "HK-React-Small", "hk-react-s")]
		[InlineData("Service-ExtraLarge", "HK-Service-ExtraLarge", "HK-Service-ExtraLarge", "hk-service-xl")]
		[InlineData("Service-Large", "HK-Service-Large", "HK-Service-Large", "hk-service-l")]
		[InlineData("Service-Medium", "HK-Service-Medium", "HK-Service-Medium", "hk-service-m")]
		[InlineData("Service-Small", "HK-Service-Small", "HK-Service-Small", "hk-service-s")]
		public async Task ContentShouldBeCorrect(string contentFolderName, string identity, string name, string shortName)
		{
			await Task.CompletedTask;

			var contentFolderPath = $"content/{contentFolderName}";

			using(var packageArchiveReader = new PackageArchiveReader(Global.NuGetPackageFile.FullName))
			{
				var entry = packageArchiveReader.GetEntry($"{contentFolderPath.TrimEnd('/')}/.template.config/template.json");

				using(var stream = await entry.OpenAsync())
				{
					using(var streamReader = new StreamReader(stream))
					{
						var content = await streamReader.ReadToEndAsync();

						var jsonElement = JsonSerializer.Deserialize<JsonElement>(content);

						Assert.Equal(identity, jsonElement.GetProperty(nameof(identity)).GetString());
						Assert.Equal(name, jsonElement.GetProperty(nameof(name)).GetString());
						Assert.Equal(shortName, jsonElement.GetProperty(nameof(shortName)).GetString());
					}
				}
			}
		}

		#endregion
	}
}