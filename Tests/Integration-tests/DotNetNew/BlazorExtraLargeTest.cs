using IntegrationTests.DotNetNew.Fixtures;
using IntegrationTests.SimpleExec.Extensions;

namespace IntegrationTests.DotNetNew
{
	/// <summary>
	/// dotnet new hk-blazor-xl --name Example-Blazor --directTemplateProcessing false/true --kubernetesImageRegistry false/true
	/// </summary>
	public class BlazorExtraLargeTest(BlazorExtraLargeFixture fixture) : TemplateTest<BlazorExtraLargeFixture>(fixture)
	{
		#region Methods

		[Fact]
		public async Task Default_Test()
		{
			await this.Test("Default");
		}

		[Fact]
		public async Task DirectTemplateProcessingIsFalse_And_KubernetesImageRegistryIsFalse_Test()
		{
			await this.Test("Default", false, false);
		}

		[Fact]
		public async Task DirectTemplateProcessingIsFalse_And_KubernetesImageRegistryIsTrue_Test()
		{
			await this.Test("KubernetesImageRegistry", false, true);
		}

		[Fact]
		public async Task DirectTemplateProcessingIsFalse_Test()
		{
			await this.Test("Default", false);
		}

		[Fact]
		public async Task DirectTemplateProcessingIsTrue_And_KubernetesImageRegistryIsFalse_Test()
		{
			await this.Test("DirectTemplateProcessing", true, false);
		}

		[Fact]
		public async Task DirectTemplateProcessingIsTrue_And_KubernetesImageRegistryIsTrue_Test()
		{
			await this.Test("DirectTemplateProcessingAndKubernetesImageRegistry", true, true);
		}

		[Fact]
		public async Task DirectTemplateProcessingIsTrue_Test()
		{
			await this.Test("DirectTemplateProcessing", true);
		}

		[Fact]
		public async Task KubernetesImageRegistryIsFalse_Test()
		{
			await this.Test("Default", null, false);
		}

		[Fact]
		public async Task KubernetesImageRegistryIsTrue_Test()
		{
			await this.Test("KubernetesImageRegistry", null, true);
		}

		private async Task Test(string resource, bool? directTemplateProcessing = null, bool? kubernetesImageRegistry = null)
		{
			var output = $"_{Guid.NewGuid()}";

			var arguments = new Dictionary<string, string>
			{
				{ "name", $"\"{output}\"" }
			};

			if(directTemplateProcessing != null)
				arguments.Add(nameof(directTemplateProcessing), directTemplateProcessing.Value.ToString().ToLowerInvariant());

			if(kubernetesImageRegistry != null)
				arguments.Add(nameof(kubernetesImageRegistry), kubernetesImageRegistry.Value.ToString().ToLowerInvariant());

			var argumentsValue = string.Join(" ", arguments.Select(item => $"--{item.Key} {item.Value}"));

			var (standardOutput, standardError) = await CommandExtension.ReadAsync($"dotnet new {this.Fixture.TemplateShortName}", argumentsValue, Global.DotNetNewProjectsDirectory.FullName);

			// When testing the standardOutput may start with: "Warning: Failed to store template cache, details: The process cannot access the file ..."
			Assert.EndsWith($"The template \"{this.Fixture.TemplateName}\" was created successfully.{Environment.NewLine}{Environment.NewLine}", standardOutput);
			Assert.Equal(string.Empty, standardError);

			var projectDirectory = new DirectoryInfo(Path.Combine(Global.DotNetNewProjectsDirectory.FullName, output));

			var buildYml = await File.ReadAllTextAsync(Path.Combine(projectDirectory.FullName, "Build.yml"));
			var deployYml = await File.ReadAllTextAsync(Path.Combine(projectDirectory.FullName, "Deploy.yml"));
			var directoriesCount = projectDirectory.GetDirectories().Length;
			var filesCount = projectDirectory.GetFiles().Length;
			var kubernetesTemplateYml = await File.ReadAllTextAsync(Path.Combine(projectDirectory.FullName, ".kubernetes", "Template.yml"));
			var pipelineYml = await File.ReadAllTextAsync(Path.Combine(projectDirectory.FullName, "Pipeline.yml"));
			var readMeMd = await File.ReadAllTextAsync(Path.Combine(projectDirectory.FullName, "ReadMe.md"));
			var variablesYml = await File.ReadAllTextAsync(Path.Combine(projectDirectory.FullName, "Variables.yml"));

			Directory.Delete(projectDirectory.FullName, true);

			var defaultResourcesDirectory = this.GetResourcesDirectory("Default");
			var resourcesDirectory = this.GetResourcesDirectory(resource);

			var expectedBuildYml = await File.ReadAllTextAsync(Path.Combine(defaultResourcesDirectory.FullName, "Build.yml"));
			Assert.Equal(expectedBuildYml, buildYml);

			var expectedDeployYml = await File.ReadAllTextAsync(Path.Combine(resourcesDirectory.FullName, "Deploy.yml"));
			Assert.Equal(expectedDeployYml, deployYml);

			Assert.Equal(4, directoriesCount);
			Assert.Equal(12, filesCount);

			var expectedKubernetesTemplateYml = await File.ReadAllTextAsync(Path.Combine(defaultResourcesDirectory.FullName, ".kubernetes", "Template.yml"));
			Assert.Equal(expectedKubernetesTemplateYml, kubernetesTemplateYml);

			var expectedPipelineYml = await File.ReadAllTextAsync(Path.Combine(defaultResourcesDirectory.FullName, "Pipeline.yml"));
			Assert.Equal(expectedPipelineYml, pipelineYml);

			var expectedReadMeMd = await File.ReadAllTextAsync(Path.Combine(resourcesDirectory.FullName, "ReadMe.md"));
			expectedReadMeMd = expectedReadMeMd.Replace("Name_76ff7a7e_db48_4849_bc2c_2790d679ce88", output.Replace("-", "_"));
			Assert.Equal(expectedReadMeMd, readMeMd);

			var expectedVariablesYml = await File.ReadAllTextAsync(Path.Combine(resourcesDirectory.FullName, "Variables.yml"));
			Assert.Equal(expectedVariablesYml, variablesYml);
		}

		#endregion
	}
}