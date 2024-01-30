namespace IntegrationTests.NuGetPackage.Content
{
	public class AspNetRazorExtraLargeTest : TemplateTest
	{
		#region Properties

		public override string BasePath => "content/AspNet-Razor-ExtraLarge";

		#endregion

		#region Methods

		[Fact]
		public async Task Content_Test()
		{
			await Task.CompletedTask;

			using(var packageArchiveReader = this.CreatePackageArchiveReader())
			{
				var files = packageArchiveReader.GetFiles(this.BasePath);
				Assert.Equal(55, files.Count());
			}
		}

		[Fact]
		public async Task DeployYaml_Test()
		{
			using(var packageArchiveReader = this.CreatePackageArchiveReader())
			{
				var entry = this.GetEntry("Deploy.yml", packageArchiveReader);
				using(var stream = entry.Open())
				{
					using(var streamReader = new StreamReader(stream))
					{
						var content = await streamReader.ReadToEndAsync();
						var expected = await GetResourceContent("Deploy.yml");

						Assert.Equal(expected, content);
					}
				}
			}
		}

		[Fact]
		public async Task EditorConfig_Test()
		{
			using(var packageArchiveReader = this.CreatePackageArchiveReader())
			{
				var entry = this.GetEntry(".editorconfig", packageArchiveReader);
				using(var stream = entry.Open())
				{
					using(var streamReader = new StreamReader(stream))
					{
						var content = await streamReader.ReadToEndAsync();

						Assert.Contains("dotnet_analyzer_diagnostic.severity = error", content);
					}
				}
			}
		}

		private static async Task<string> GetResourceContent(string fileName)
		{
			var path = Path.Combine(Global.ProjectDirectory.FullName, "NuGetPackage", "Content", "Resources", "AspNetRazorExtraLarge", fileName);

			return await File.ReadAllTextAsync(path);
		}

		[Fact]
		public async Task GitIgnore_Test()
		{
			using(var packageArchiveReader = this.CreatePackageArchiveReader())
			{
				var entry = this.GetEntry(".gitignore", packageArchiveReader);
				using(var stream = entry.Open())
				{
					using(var streamReader = new StreamReader(stream))
					{
						var content = await streamReader.ReadToEndAsync();

						Assert.Contains("Source/Application/wwwroot/Scripts/*", content);
						Assert.Contains("!Source/Application/wwwroot/Scripts/.gitkeep", content);
						Assert.Contains("Source/Application/wwwroot/Style/*", content);
						Assert.Contains("!Source/Application/wwwroot/Style/.gitkeep", content);
					}
				}
			}
		}

		[Fact]
		public async Task NuGetConfig_Test()
		{
			using(var packageArchiveReader = this.CreatePackageArchiveReader())
			{
				var entry = this.GetEntry("NuGet.config", packageArchiveReader);
				using(var stream = entry.Open())
				{
					using(var streamReader = new StreamReader(stream))
					{
						var content = await streamReader.ReadToEndAsync();

						Assert.Contains("\t\t<add key=\"nuget.org\" protocolVersion=\"3\" value=\"https://api.nuget.org/v3/index.json\" />", content);
					}
				}
			}
		}

		[Fact]
		public async Task ReadMe_Test()
		{
			using(var packageArchiveReader = this.CreatePackageArchiveReader())
			{
				var entry = this.GetEntry("ReadMe.md", packageArchiveReader);
				using(var stream = entry.Open())
				{
					using(var streamReader = new StreamReader(stream))
					{
						var content = await streamReader.ReadToEndAsync();
						var expected = await GetResourceContent("ReadMe.md");

						Assert.Equal(expected, content);
					}
				}
			}
		}

		[Fact]
		public async Task VariablesYaml_Test()
		{
			using(var packageArchiveReader = this.CreatePackageArchiveReader())
			{
				var entry = this.GetEntry("Variables.yml", packageArchiveReader);
				using(var stream = entry.Open())
				{
					using(var streamReader = new StreamReader(stream))
					{
						var content = await streamReader.ReadToEndAsync();
						var expected = await GetResourceContent("Variables.yml");

						Assert.Equal(expected, content);
					}
				}
			}
		}

		#endregion
	}
}