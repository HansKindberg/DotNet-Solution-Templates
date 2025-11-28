using NuGet.Packaging;

namespace IntegrationTests.NuGetPackage
{
	/// <summary>
	/// NuGet Client SDK - Read a package: https://learn.microsoft.com/en-us/nuget/reference/nuget-client-sdk#read-a-package
	/// </summary>
	public class PackageContentTest
	{
		#region Methods

		[Fact]
		public async Task NuGet_BuildItems_ShouldBeEmpty()
		{
			await Task.CompletedTask;

			using(var packageArchiveReader = new PackageArchiveReader(Global.NuGetPackageFile.FullName))
			{
				Assert.Empty(packageArchiveReader.GetBuildItems());
			}
		}

		[Fact]
		public async Task NuGet_ContentItems_Test()
		{
			await Task.CompletedTask;

			using(var packageArchiveReader = new PackageArchiveReader(Global.NuGetPackageFile.FullName))
			{
				var contentItems = packageArchiveReader.GetContentItems().ToList();
				Assert.Equal(5, contentItems.Count);

				const string expectedVersion = "0.0.0.0";

				Assert.False(contentItems[0].HasEmptyFolder);
				Assert.Equal(1072, contentItems[0].Items.Count());
				Assert.True(contentItems[0].TargetFramework.AllFrameworkVersions);
				Assert.Equal("Any,Version=v0.0", contentItems[0].TargetFramework.DotNetFrameworkName);
				Assert.Empty(contentItems[0].TargetFramework.DotNetPlatformName);
				Assert.Equal("Any", contentItems[0].TargetFramework.Framework);
				Assert.Equal("any", contentItems[0].TargetFramework.GetShortFolderName());
				Assert.False(contentItems[0].TargetFramework.HasPlatform);
				Assert.False(contentItems[0].TargetFramework.HasProfile);
				Assert.False(contentItems[0].TargetFramework.IsAgnostic);
				Assert.True(contentItems[0].TargetFramework.IsAny);
				Assert.False(contentItems[0].TargetFramework.IsPCL);
				Assert.False(contentItems[0].TargetFramework.IsPackageBased);
				Assert.False(contentItems[0].TargetFramework.IsSpecificFramework);
				Assert.False(contentItems[0].TargetFramework.IsUnsupported);
				Assert.Empty(contentItems[0].TargetFramework.Platform);
				Assert.Equal(expectedVersion, contentItems[0].TargetFramework.PlatformVersion.ToString());
				Assert.Empty(contentItems[0].TargetFramework.Profile);
				Assert.Equal(expectedVersion, contentItems[0].TargetFramework.Version.ToString());

				Assert.False(contentItems[1].HasEmptyFolder);
				Assert.Equal(53, contentItems[1].Items.Count());
				Assert.True(contentItems[1].TargetFramework.AllFrameworkVersions);
				Assert.Equal("ASP.NET,Version=v0.0,Profile=Razor-ExtraLarge", contentItems[1].TargetFramework.DotNetFrameworkName);
				Assert.Empty(contentItems[1].TargetFramework.DotNetPlatformName);
				Assert.Equal("ASP.NET", contentItems[1].TargetFramework.Framework);
				Assert.Equal("aspnet-razor-extralarge", contentItems[1].TargetFramework.GetShortFolderName());
				Assert.False(contentItems[1].TargetFramework.HasPlatform);
				Assert.True(contentItems[1].TargetFramework.HasProfile);
				Assert.False(contentItems[1].TargetFramework.IsAgnostic);
				Assert.False(contentItems[1].TargetFramework.IsAny);
				Assert.False(contentItems[1].TargetFramework.IsPCL);
				Assert.False(contentItems[1].TargetFramework.IsPackageBased);
				Assert.True(contentItems[1].TargetFramework.IsSpecificFramework);
				Assert.False(contentItems[1].TargetFramework.IsUnsupported);
				Assert.Empty(contentItems[1].TargetFramework.Platform);
				Assert.Equal(expectedVersion, contentItems[1].TargetFramework.PlatformVersion.ToString());
				Assert.Equal("Razor-ExtraLarge", contentItems[1].TargetFramework.Profile);
				Assert.Equal(expectedVersion, contentItems[1].TargetFramework.Version.ToString());

				Assert.False(contentItems[2].HasEmptyFolder);
				Assert.Equal(45, contentItems[2].Items.Count());
				Assert.True(contentItems[2].TargetFramework.AllFrameworkVersions);
				Assert.Equal("ASP.NET,Version=v0.0,Profile=Razor-Large", contentItems[2].TargetFramework.DotNetFrameworkName);
				Assert.Empty(contentItems[2].TargetFramework.DotNetPlatformName);
				Assert.Equal("ASP.NET", contentItems[2].TargetFramework.Framework);
				Assert.Equal("aspnet-razor-large", contentItems[2].TargetFramework.GetShortFolderName());
				Assert.False(contentItems[2].TargetFramework.HasPlatform);
				Assert.True(contentItems[2].TargetFramework.HasProfile);
				Assert.False(contentItems[2].TargetFramework.IsAgnostic);
				Assert.False(contentItems[2].TargetFramework.IsAny);
				Assert.False(contentItems[2].TargetFramework.IsPCL);
				Assert.False(contentItems[2].TargetFramework.IsPackageBased);
				Assert.True(contentItems[2].TargetFramework.IsSpecificFramework);
				Assert.False(contentItems[2].TargetFramework.IsUnsupported);
				Assert.Empty(contentItems[2].TargetFramework.Platform);
				Assert.Equal(expectedVersion, contentItems[2].TargetFramework.PlatformVersion.ToString());
				Assert.Equal("Razor-Large", contentItems[2].TargetFramework.Profile);
				Assert.Equal(expectedVersion, contentItems[2].TargetFramework.Version.ToString());

				Assert.False(contentItems[3].HasEmptyFolder);
				Assert.Equal(41, contentItems[3].Items.Count());
				Assert.True(contentItems[3].TargetFramework.AllFrameworkVersions);
				Assert.Equal("ASP.NET,Version=v0.0,Profile=Razor-Medium", contentItems[3].TargetFramework.DotNetFrameworkName);
				Assert.Empty(contentItems[3].TargetFramework.DotNetPlatformName);
				Assert.Equal("ASP.NET", contentItems[3].TargetFramework.Framework);
				Assert.Equal("aspnet-razor-medium", contentItems[3].TargetFramework.GetShortFolderName());
				Assert.False(contentItems[3].TargetFramework.HasPlatform);
				Assert.True(contentItems[3].TargetFramework.HasProfile);
				Assert.False(contentItems[3].TargetFramework.IsAgnostic);
				Assert.False(contentItems[3].TargetFramework.IsAny);
				Assert.False(contentItems[3].TargetFramework.IsPCL);
				Assert.False(contentItems[3].TargetFramework.IsPackageBased);
				Assert.True(contentItems[3].TargetFramework.IsSpecificFramework);
				Assert.False(contentItems[3].TargetFramework.IsUnsupported);
				Assert.Empty(contentItems[3].TargetFramework.Platform);
				Assert.Equal(expectedVersion, contentItems[3].TargetFramework.PlatformVersion.ToString());
				Assert.Equal("Razor-Medium", contentItems[3].TargetFramework.Profile);
				Assert.Equal(expectedVersion, contentItems[3].TargetFramework.Version.ToString());

				Assert.False(contentItems[4].HasEmptyFolder);
				Assert.Equal(35, contentItems[4].Items.Count());
				Assert.True(contentItems[4].TargetFramework.AllFrameworkVersions);
				Assert.Equal("ASP.NET,Version=v0.0,Profile=Razor-Small", contentItems[4].TargetFramework.DotNetFrameworkName);
				Assert.Empty(contentItems[4].TargetFramework.DotNetPlatformName);
				Assert.Equal("ASP.NET", contentItems[4].TargetFramework.Framework);
				Assert.Equal("aspnet-razor-small", contentItems[4].TargetFramework.GetShortFolderName());
				Assert.False(contentItems[4].TargetFramework.HasPlatform);
				Assert.True(contentItems[4].TargetFramework.HasProfile);
				Assert.False(contentItems[4].TargetFramework.IsAgnostic);
				Assert.False(contentItems[4].TargetFramework.IsAny);
				Assert.False(contentItems[4].TargetFramework.IsPCL);
				Assert.False(contentItems[4].TargetFramework.IsPackageBased);
				Assert.True(contentItems[4].TargetFramework.IsSpecificFramework);
				Assert.False(contentItems[4].TargetFramework.IsUnsupported);
				Assert.Empty(contentItems[4].TargetFramework.Platform);
				Assert.Equal(expectedVersion, contentItems[4].TargetFramework.PlatformVersion.ToString());
				Assert.Equal("Razor-Small", contentItems[4].TargetFramework.Profile);
				Assert.Equal(expectedVersion, contentItems[4].TargetFramework.Version.ToString());
			}
		}

		[Fact]
		public async Task NuGet_DependencyGroups_ShouldBeEmpty()
		{
			await Task.CompletedTask;

			using(var packageArchiveReader = new PackageArchiveReader(Global.NuGetPackageFile.FullName))
			{
				Assert.Empty(packageArchiveReader.NuspecReader.GetDependencyGroups());
			}
		}

		[Fact]
		public async Task NuGet_Files_Test()
		{
			await Task.CompletedTask;

			using(var packageArchiveReader = new PackageArchiveReader(Global.NuGetPackageFile.FullName))
			{
				var files = packageArchiveReader.GetFiles();
				Assert.Equal(1251, files.Count());
			}
		}

		[Fact]
		public async Task NuGet_FrameworkItems_ShouldBeEmpty()
		{
			await Task.CompletedTask;

			using(var packageArchiveReader = new PackageArchiveReader(Global.NuGetPackageFile.FullName))
			{
				Assert.Empty(packageArchiveReader.GetFrameworkItems());
			}
		}

		[Fact]
		public async Task NuGet_LibItems_ShouldBeEmpty()
		{
			await Task.CompletedTask;

			using(var packageArchiveReader = new PackageArchiveReader(Global.NuGetPackageFile.FullName))
			{
				Assert.Empty(packageArchiveReader.GetLibItems());
			}
		}

		[Fact]
		public async Task NuGet_PackageDependencies_ShouldBeEmpty()
		{
			await Task.CompletedTask;

			using(var packageArchiveReader = new PackageArchiveReader(Global.NuGetPackageFile.FullName))
			{
				Assert.Empty(packageArchiveReader.GetPackageDependencies());
			}
		}

		[Fact]
		public async Task NuGet_PackageTypes_Test()
		{
			await Task.CompletedTask;

			using(var packageArchiveReader = new PackageArchiveReader(Global.NuGetPackageFile.FullName))
			{
				var packageTypes = packageArchiveReader.NuspecReader.GetPackageTypes();
				_ = Assert.Single(packageTypes);
				Assert.Equal("Template", actual: packageTypes[0].Name);
			}
		}

		[Fact]
		public async Task NuGet_Readme_Test()
		{
			await Task.CompletedTask;

			using(var packageArchiveReader = new PackageArchiveReader(Global.NuGetPackageFile.FullName))
			{
				Assert.Equal("ReadMe.md", packageArchiveReader.NuspecReader.GetReadme());
			}
		}

		[Fact]
		public async Task NuGet_ReferenceItems_ShouldBeEmpty()
		{
			await Task.CompletedTask;

			using(var packageArchiveReader = new PackageArchiveReader(Global.NuGetPackageFile.FullName))
			{
				Assert.Empty(packageArchiveReader.GetReferenceItems());
			}
		}

		[Fact]
		public async Task NuGet_Specification_Test()
		{
			await Task.CompletedTask;

			using(var packageArchiveReader = new PackageArchiveReader(Global.NuGetPackageFile.FullName))
			{
				var nuspecReader = packageArchiveReader.NuspecReader;
				Assert.Equal("Hans Kindberg - open source", nuspecReader.GetAuthors());
				Assert.Equal("A template-package for creating solutions, with one or more projects, in dotnet / Visual Studio.", nuspecReader.GetDescription());
				Assert.Equal(Global.NuGetPackageName, nuspecReader.GetId());
				Assert.Equal(Global.NuGetPackageVersion, nuspecReader.GetVersion().OriginalVersion);
			}
		}

		[Fact]
		public async Task NuGet_ToolItems_ShouldBeEmpty()
		{
			await Task.CompletedTask;

			using(var packageArchiveReader = new PackageArchiveReader(Global.NuGetPackageFile.FullName))
			{
				Assert.Empty(packageArchiveReader.GetToolItems());
			}
		}

		#endregion
	}
}