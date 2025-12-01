using IntegrationTests.DotNetNew.Fixtures;
using IntegrationTests.SimpleExec.Extensions;

namespace IntegrationTests.DotNetNew
{
	/// <summary>
	/// dotnet new hk-nuget-package-xl --name Example.NuGetPackage
	/// </summary>
	public class NuGetPackageExtraLargeTest(NuGetPackageExtraLargeFixture fixture) : TemplateTest<NuGetPackageExtraLargeFixture>(fixture)
	{
		#region Methods

		[Fact]
		public async Task Test()
		{
			var output = $"_{Guid.NewGuid()}";

			var arguments = new Dictionary<string, string>
			{
				{ "name", $"\"{output}\"" }
			};

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
			var pipelineYml = await File.ReadAllTextAsync(Path.Combine(projectDirectory.FullName, "Pipeline.yml"));
			var readMeMd = await File.ReadAllTextAsync(Path.Combine(projectDirectory.FullName, "ReadMe.md"));
			var variablesYml = await File.ReadAllTextAsync(Path.Combine(projectDirectory.FullName, "Variables.yml"));

			Directory.Delete(projectDirectory.FullName, true);

			var resourcesDirectory = this.GetResourcesDirectory(string.Empty);

			var expectedBuildYml = await File.ReadAllTextAsync(Path.Combine(resourcesDirectory.FullName, "Build.yml"));
			Assert.Equal(expectedBuildYml, buildYml);

			var expectedDeployYml = await File.ReadAllTextAsync(Path.Combine(resourcesDirectory.FullName, "Deploy.yml"));
			Assert.Equal(expectedDeployYml, deployYml);

			Assert.Equal(2, directoriesCount);
			Assert.Equal(11, filesCount);

			var expectedPipelineYml = await File.ReadAllTextAsync(Path.Combine(resourcesDirectory.FullName, "Pipeline.yml"));
			Assert.Equal(expectedPipelineYml, pipelineYml);

			var expectedReadMeMd = await File.ReadAllTextAsync(Path.Combine(resourcesDirectory.FullName, "ReadMe.md"));
			expectedReadMeMd = expectedReadMeMd.Replace("Name-._76ff7a7e-._db48-._4849-._bc2c-._2790d679ce88", output);
			Assert.Equal(expectedReadMeMd, readMeMd);

			var expectedVariablesYml = await File.ReadAllTextAsync(Path.Combine(resourcesDirectory.FullName, "Variables.yml"));
			Assert.Equal(expectedVariablesYml, variablesYml);
		}

		#endregion
	}
}