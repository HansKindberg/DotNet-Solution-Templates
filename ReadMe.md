# DotNet-Solution-Templates

A template-package (NuGet) for creating solutions, with one or more projects, in dotnet / Visual Studio.

For the moment, because of an issue, the templates are not enabled in Visual Studio. See: [Template.Source.json](/Source/Templates/Common/All/.template.config/Template.Source.json#L54)

[![NuGet](https://img.shields.io/nuget/v/HansKindberg-DotNet-Solution-Templates.svg?label=NuGet)](https://www.nuget.org/packages/HansKindberg-DotNet-Solution-Templates)

## 1 Using the templates

### 1.1 Install

	dotnet new install HansKindberg-DotNet-Solution-Templates

or (if testing locally)

	dotnet new install HansKindberg-DotNet-Solution-Templates --nuget-source "C:\Data\Projects\HansKindberg\DotNet-Solution-Templates\Source\Templates\bin\Debug"

or (if the package is in another nuget source)

	dotnet new install HansKindberg-DotNet-Solution-Templates --nuget-source "https://nuget.example.org/v3/index.json"

- [dotnet new install](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new-install)

### 1.2 Uninstall

	dotnet new uninstall HansKindberg-DotNet-Solution-Templates

### [1.3 Run](/Source/Templates/ReadMe.md#1-run)

## [2 Solution structure](/Source/Templates/ReadMe.md#2-solution-structure)

## 3 Development

I am using Visual Studio 2022 - 17.8.3 when starting this project.

This project/solution was initially created with:

	dotnet new templatepack -n "Templates"

To have "templatepack" you need to install [Microsoft.TemplateEngine.Authoring.Templates](https://www.nuget.org/packages/Microsoft.TemplateEngine.Authoring.Templates):

	dotnet new install Microsoft.TemplateEngine.Authoring.Templates

### 3.1 Adjustments

After creating the project with:

	dotnet new templatepack -n "Templates"

I had to do some adjustments:

	<Project Sdk="Microsoft.NET.Sdk">
		<PropertyGroup>
			...
			<GeneratePackageOnBuild>true</GeneratePackageOnBuild><!-- Added this row. -->
			...
			<SuppressDependenciesWhenPacking>true</SuppressDependenciesWhenPacking><!-- Added this row. -->
			...
		</PropertyGroup>
		...
		<ItemGroup>
			...
			<Content Include="content\**\*" Exclude="content\**\bin\**;content\**\obj\**">
				<PackagePath>content</PackagePath><!-- Added this row. -->
			</Content>
			...
		</ItemGroup>
		...
	</Project>

Got help by looking at:

- https://github.com/dotnet/sdk/blob/main/template_feed/Microsoft.DotNet.Common.ProjectTemplates.9.0/Microsoft.DotNet.Common.ProjectTemplates.9.0.csproj

### 3.2 Install / uninstall

- [dotnet new install](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new-install)

How to install/uninstall during development.

#### 3.2.1 Locally built NuGet-package

cd to Source\Templates\bin\Debug.

Install:

	dotnet new install HansKindberg-DotNet-Solution-Templates.0.0.1.nupkg

Uninstall:

	dotnet new uninstall HansKindberg-DotNet-Solution-Templates

#### 3.2.2 Local folder

Install:

	dotnet new install <PATH>

Uninstall:

	dotnet new uninstall <PATH>

Where `<PATH>` is the path to the folder containing .template.config.

### 3.3 Try the templates

cd to your project directory.

	dotnet new hk-aspnet-razor-l --name hk-aspnet-razor-l

	dotnet new hk-aspnet-razor-m --name hk-aspnet-razor-m

	dotnet new hk-aspnet-razor-s --name hk-aspnet-razor-s

	dotnet new hk-aspnet-razor-xl --name hk-aspnet-razor-xl --directTemplateProcessing false/true --kubernetesImageRegistry false/true

	dotnet new hk-blazor-l --name hk-blazor-l

	dotnet new hk-blazor-m --name hk-blazor-m

	dotnet new hk-blazor-s --name hk-blazor-s

	dotnet new hk-blazor-xl --name hk-blazor-xl --directTemplateProcessing false/true --kubernetesImageRegistry false/true

	dotnet new hk-blazor-duende-l --name hk-blazor-duende-l

	dotnet new hk-blazor-duende-m --name hk-blazor-duende-m

	dotnet new hk-blazor-duende-s --name hk-blazor-duende-s

	dotnet new hk-blazor-duende-xl --name hk-blazor-duende-xl --directTemplateProcessing false/true --kubernetesImageRegistry false/true

	dotnet new hk-nuget-package-l --name hk.nuget.package.l

	dotnet new hk-nuget-package-m --name hk.nuget.package.m

	dotnet new hk-nuget-package-s --name hk.nuget.package.s

	dotnet new hk-nuget-package-xl --name hk.nuget.package.xl

	dotnet new hk-react-l --name hk-react-l

	dotnet new hk-react-m --name hk-react-m

	dotnet new hk-react-s --name hk-react-s

	dotnet new hk-react-xl --name hk-react-xl --directTemplateProcessing false/true --kubernetesImageRegistry false/true

	dotnet new hk-react-duende-l --name hk-react-duende-l

	dotnet new hk-react-duende-m --name hk-react-duende-m

	dotnet new hk-react-duende-s --name hk-react-duende-s

	dotnet new hk-react-duende-xl --name hk-react-duende-xl --directTemplateProcessing false/true --kubernetesImageRegistry false/true

	dotnet new hk-service-l --name hk-service-l

	dotnet new hk-service-m --name hk-service-m

	dotnet new hk-service-s --name hk-service-s

	dotnet new hk-service-xl --name hk-service-xl --directTemplateProcessing false/true --kubernetesImageRegistry false/true

### 3.4 Important

We have experienced problems when the solution-files included in the templates are not **UTF-8-BOM** encoded. If we make changes in the *.sln files we should verify that they are **UTF-8-BOM** encoded. If not, make them **UTF-8-BOM** encoded with Notepadd++ for example.

This seems to happen even if we have this in .editorconfig:

	[*.{cshtml,sln}]
	charset = utf-8-bom

### 3.5 Links

- [Package authoring best practices](https://learn.microsoft.com/en-us/nuget/create-packages/package-authoring-best-practices)

## 4 Tests

There is a lot of "IO" in the integration-tests. Making the tests run sequential helps:

- [xunit.runner.json - "parallelizeTestCollections": false](/Tests/Integration-tests/xunit.runner.json#L4)
- [Integration-tests - xunit.runner.json](/Tests/Integration-tests/Integration-tests.csproj#L16)

If we run the tests in parallel we often get failing tests.

## 5 Thanks Damien Bowden

His article/work led me the way to build "solution"-templates:

- [CREATING DOTNET SOLUTION AND PROJECT TEMPLATES](https://damienbod.com/2022/08/15/creating-dotnet-solution-and-project-templates/)
- [NuGet – Blazor.BFF.OpenIDConnect.Template](https://www.nuget.org/packages/Blazor.BFF.OpenIDConnect.Template)
- [GitHub – Blazor.BFF.OpenIDConnect.Template](https://github.com/damienbod/Blazor.BFF.OpenIDConnect.Template)

## 6 Links

- https://github.com/sayedihashimi/template-sample
- https://github.com/dotnet/templating
- [Reference for template.json](https://github.com/dotnet/templating/wiki/Reference-for-template.json)
- [Reference for template.json - guids](https://github.com/dotnet/templating/wiki/Reference-for-template.json#guids)
- [Tutorial: Create a template package - Create a template package project](https://learn.microsoft.com/en-us/dotnet/core/tutorials/cli-templates-create-template-package?pivots=dotnet-8-0#create-a-template-package-project)
- [Visual Studio solution-structure for Docker-project with .editorconfig, Directory.Build.props and Directory.Build.targets](https://hanskindberg.wordpress.com/2023/12/21/visual-studio-solution-structure-for-docker-project-with-editorconfig-directory-build-props-and-directory-build-targets/)
- [Google: build visual studio template package](https://www.google.com/search?q=build+visual+studio+template+package)
- [Tutorial: Create a template package](https://learn.microsoft.com/en-us/dotnet/core/tutorials/cli-templates-create-template-package?pivots=dotnet-8-0)
- [Tutorial: Create a project template](https://learn.microsoft.com/en-us/dotnet/core/tutorials/cli-templates-create-project-template)
- https://github.com/dotnet/sdk/blob/main/template_feed/Microsoft.DotNet.Common.ProjectTemplates.9.0/Microsoft.DotNet.Common.ProjectTemplates.9.0.csproj
- [Google: template.json tags type solution](https://www.google.com/search?q=template.json+tags+type+solution)
- https://github.com/dotnet/templating/tree/main/dotnet-template-samples/content/05-multi-project
- [Create dotnet new template with multiple projects](https://medium.com/@stoyanshopov032/create-dotnet-new-template-with-multiple-projects-5df240ed81b4)
- [How to create your own templates for dotnet new](https://devblogs.microsoft.com/dotnet/how-to-create-your-own-templates-for-dotnet-new/)
- https://github.com/dotnet/dotnet-template-samples
- https://github.com/dotnet/dotnet-template-samples/tree/master/05-multi-project
- [Create Solution Template - group of projects #611](https://github.com/dotnet/templating/issues/611)
- [How does project system determine if the project is ASPNET or generic C#? #3079](https://github.com/dotnet/project-system/issues/3079)