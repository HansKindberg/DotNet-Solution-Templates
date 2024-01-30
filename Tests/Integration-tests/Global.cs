using System.Diagnostics;
using System.Reflection;

namespace IntegrationTests
{
	public static class Global
	{
		#region Primary fields

		public static readonly DirectoryInfo BaseDirectory = new(AppDomain.CurrentDomain.BaseDirectory);
		public static readonly DirectoryInfo ProjectDirectory = BaseDirectory.Parent!.Parent!.Parent!;
		public static readonly DirectoryInfo SolutionDirectory = BaseDirectory.Parent!.Parent!.Parent!.Parent!.Parent!;
		public static readonly Assembly TemplatesAssembly = typeof(Templates.Global).Assembly;
		public static readonly DirectoryInfo TemplatesProjectDirectory = new(Path.Combine(SolutionDirectory.FullName, "Source", "Templates"));
		public static readonly DirectoryInfo TemplatesProjectOutputDirectory = new(Path.Combine(TemplatesProjectDirectory.FullName, BaseDirectory.Parent!.Parent!.Name, BaseDirectory.Parent!.Name));

		#endregion

		#region Secondary fields

		public static readonly DirectoryInfo DotNetNewContentDirectory = new(Path.Combine(ProjectDirectory.FullName, "DotNetNew", "Content"));
		public static readonly DirectoryInfo DotNetNewProjectsDirectory = new(Path.Combine(ProjectDirectory.FullName, "DotNetNew", "Projects"));
		public static readonly DirectoryInfo DotNetNewResourcesDirectory = new(Path.Combine(ProjectDirectory.FullName, "DotNetNew", "Resources"));
		public static readonly string NuGetPackageName = TemplatesAssembly.GetName().Name!;
		public static readonly string NuGetPackageVersion = FileVersionInfo.GetVersionInfo(TemplatesAssembly.Location).ProductVersion!;
		public static readonly FileInfo NuGetPackageFile = new(Path.Combine(TemplatesProjectOutputDirectory.FullName, $"{NuGetPackageName}.{NuGetPackageVersion}.nupkg"));
		public static readonly DirectoryInfo TemplatesContentDirectory = new(Path.Combine(TemplatesProjectDirectory.FullName, "Content"));

		#endregion
	}
}