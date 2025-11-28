# HansKindberg-DotNet-Solution-Templates

A template-package for creating solutions, with one or more projects, in dotnet / Visual Studio.

## 1 Run

The prefix **HK** is for **Hans Kindberg**, my initials.

Small, Medium, Large and ExtraLarge is for "how much" the created solution will contain. See [2 Solution structure](#2-solution-structure) below.

1. cd to your project directory
2. Run any of the following commands - change the *--name* parameter to whatever you want

The most of the *-ExtraLarge templates have two extra parameters:

- **directTemplateProcessing** false/true
	- if **false** (default): the pipeline-files are adapted for processing the Kubernetes template to a git-repository and from there handled by Argo CD
	- if **true**: the pipeline-files are adapted for processing the Kubernetes template directly to Kubernetes
- **kubernetesImageRegistry** false/true
	- if **false** (default): the pipeline-files are adapted for using an external image-registry, eg. https://hub.docker.com
	- if **true**: the pipeline-files are adapted for using the internal Kubernetes image-registry

### 1.1 HK-AspNet-Razor-ExtraLarge

	dotnet new hk-aspnet-razor-xl --name Example-Site --directTemplateProcessing false/true --kubernetesImageRegistry false/true

### 1.2 HK-AspNet-Razor-Large

	dotnet new hk-aspnet-razor-l --name Example-Site

### 1.3 HK-AspNet-Razor-Medium

	dotnet new hk-aspnet-razor-m --name Example-Site

### 1.4 HK-AspNet-Razor-Small

	dotnet new hk-aspnet-razor-s --name Example-Site

### 1.5 HK-Blazor-ExtraLarge

	dotnet new hk-blazor-xl --name Example-Blazor --directTemplateProcessing false/true --kubernetesImageRegistry false/true

### 1.6 HK-Blazor-Large

	dotnet new hk-blazor-l --name Example-Blazor

### 1.7 HK-Blazor-Medium

	dotnet new hk-blazor-m --name Example-Blazor

### 1.8 HK-Blazor-Small

	dotnet new hk-blazor-s --name Example-Blazor

### 1.9 HK-Blazor-Duende-ExtraLarge

	dotnet new hk-blazor-duende-xl --name Example-Blazor-Duende --directTemplateProcessing false/true --kubernetesImageRegistry false/true

### 1.10 HK-Blazor-Duende-Large

	dotnet new hk-blazor-duende-l --name Example-Blazor-Duende

### 1.11 HK-Blazor-Duende-Medium

	dotnet new hk-blazor-duende-m --name Example-Blazor-Duende

### 1.12 HK-Blazor-Duende-Small

	dotnet new hk-blazor-duende-s --name Example-Blazor-Duende

### 1.13 HK-NuGet-Package-ExtraLarge

	dotnet new hk-nuget-package-xl --name Example.NuGetPackage

### 1.14 HK-NuGet-Package-Large

	dotnet new hk-nuget-package-l --name Example.NuGetPackage

### 1.15 HK-NuGet-Package-Medium

	dotnet new hk-nuget-package-m --name Example.NuGetPackage

### 1.16 HK-NuGet-Package-Small

	dotnet new hk-nuget-package-s --name Example.NuGetPackage

### 1.17 HK-React-ExtraLarge

	dotnet new hk-react-xl --name Example-React --directTemplateProcessing false/true --kubernetesImageRegistry false/true

### 1.18 HK-React-Large

	dotnet new hk-react-l --name Example-React

### 1.19 HK-React-Medium

	dotnet new hk-react-m --name Example-React

### 1.20 HK-React-Small

	dotnet new hk-react-s --name Example-React

### 1.21 HK-React-Duende-ExtraLarge

	dotnet new hk-react-duende-xl --name Example-React-Duende --directTemplateProcessing false/true --kubernetesImageRegistry false/true

### 1.22 HK-React-Duende-Large

	dotnet new hk-react-duende-l --name Example-React-Duende

### 1.23 HK-React-Duende-Medium

	dotnet new hk-react-duende-m --name Example-React-Duende

### 1.24 HK-React-Duende-Small

	dotnet new hk-react-duende-s --name Example-React-Duende

### 1.25 HK-Service-ExtraLarge

	dotnet new hk-service-xl --name Example-Service --directTemplateProcessing false/true --kubernetesImageRegistry false/true

### 1.26 HK-Service-Large

	dotnet new hk-service-l --name Example-Service

### 1.27 HK-Service-Medium

	dotnet new hk-service-m --name Example-Service

### 1.28 HK-Service-Small

	dotnet new hk-service-s --name Example-Service

## 2 Solution structure

The templates will create the following solution structure.

### 2.1 HK-AspNet-Razor-ExtraLarge

- .kubernetes
	- EgressFirewall.development-cluster.yml
	- EgressFirewall.production-cluster.yml
	- ReadMe.md
	- Template.yml
- Source
	- Application
		- ...
		- Application.csproj
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Dockerfile
		- ...
- Tests
	- Integration-tests
		- Integration-tests.csproj
	- Unit-tests
		- Unit-tests.csproj
	- .editorconfig
	- Directory.Build.props
	- Directory.Build.targets
- .dockerignore
- .editorconfig
- .gitignore
- Build.yml
- Deploy.yml
- Directory.Build.props
- Directory.Build.targets
- Name.sln (the --name parameter when you create it)
- NuGet.config
- Pipeline.yml
- ReadMe.md
- Variables.yml

### 2.2 HK-AspNet-Razor-Large

- Source
	- Application
		- ...
		- Application.csproj
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Dockerfile
		- ...
- Tests
	- Integration-tests
		- Integration-tests.csproj
	- Unit-tests
		- Unit-tests.csproj
	- .editorconfig
	- Directory.Build.props
	- Directory.Build.targets
- .dockerignore
- .editorconfig
- .gitignore
- Directory.Build.props
- Directory.Build.targets
- Name.sln (the --name parameter when you create it)
- NuGet.config
- ReadMe.md

### 2.3 HK-AspNet-Razor-Medium

- Source
	- Application
		- ...
		- Application.csproj
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Dockerfile
		- ...
- Tests
	- Integration-tests
		- Integration-tests.csproj
	- Unit-tests
		- Unit-tests.csproj
	- .editorconfig
- .dockerignore
- .editorconfig
- .gitignore
- Name.sln (the --name parameter when you create it)
- NuGet.config
- ReadMe.md

### 2.4 HK-AspNet-Razor-Small

- Source
	- Application
		- ...
		- Application.csproj
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Dockerfile
		- ...
- .dockerignore
- .editorconfig
- .gitignore
- Name.sln (the --name parameter when you create it)
- NuGet.config
- ReadMe.md

### 2.5 HK-Blazor-ExtraLarge

- .kubernetes
	- EgressFirewall.development-cluster.yml
	- EgressFirewall.production-cluster.yml
	- ReadMe.md
	- Template.yml
- Source
	- Bff
		- ...
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Bff.csproj
		- Dockerfile
		- ...
	- Shared
		- ...
		- Shared.csproj
	- Spa
		- ...
		- _Imports.razor
		- App.razor
		- ...
		- Program.cs
		- Spa.csproj
		- ...
- Tests
	- Integration-tests
		- Bff
			- ...
		- Shared
			- ...
		- Spa
			- ...
		- Integration-tests.csproj
	- Unit-tests
		- Bff
			- ...
		- Shared
			- ...
		- Spa
			- ...
		- Unit-tests.csproj
	- .editorconfig
	- Directory.Build.props
	- Directory.Build.targets
- .dockerignore
- .editorconfig
- .gitignore
- Build.yml
- Deploy.yml
- Directory.Build.props
- Directory.Build.targets
- Name.sln (the --name parameter when you create it)
- NuGet.config
- Pipeline.yml
- ReadMe.md
- Variables.yml

### 2.6 HK-Blazor-Large

- Source
	- Bff
		- ...
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Bff.csproj
		- Dockerfile
		- ...
	- Shared
		- ...
		- Shared.csproj
	- Spa
		- ...
		- _Imports.razor
		- App.razor
		- ...
		- Program.cs
		- Spa.csproj
		- ...
- Tests
	- Integration-tests
		- Bff
			- ...
		- Shared
			- ...
		- Spa
			- ...
		- Integration-tests.csproj
	- Unit-tests
		- Bff
			- ...
		- Shared
			- ...
		- Spa
			- ...
		- Unit-tests.csproj
	- .editorconfig
	- Directory.Build.props
	- Directory.Build.targets
- .dockerignore
- .editorconfig
- .gitignore
- Directory.Build.props
- Directory.Build.targets
- Name.sln (the --name parameter when you create it)
- NuGet.config
- ReadMe.md

### 2.7 HK-Blazor-Medium

- Source
	- Bff
		- ...
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Bff.csproj
		- Dockerfile
		- ...
	- Shared
		- ...
		- Shared.csproj
	- Spa
		- ...
		- _Imports.razor
		- App.razor
		- ...
		- Program.cs
		- Spa.csproj
		- ...
- Tests
	- Integration-tests
		- Bff
			- ...
		- Shared
			- ...
		- Spa
			- ...
		- Integration-tests.csproj
	- Unit-tests
		- Bff
			- ...
		- Shared
			- ...
		- Spa
			- ...
		- Unit-tests.csproj
	- .editorconfig
- .dockerignore
- .editorconfig
- .gitignore
- Name.sln (the --name parameter when you create it)
- NuGet.config
- ReadMe.md

### 2.8 HK-Blazor-Small

- Source
	- Bff
		- ...
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Bff.csproj
		- Dockerfile
		- ...
	- Shared
		- ...
		- Shared.csproj
	- Spa
		- ...
		- _Imports.razor
		- App.razor
		- ...
		- Program.cs
		- Spa.csproj
		- ...
- .dockerignore
- .editorconfig
- .gitignore
- Name.sln (the --name parameter when you create it)
- NuGet.config
- ReadMe.md

### 2.9 HK-Blazor-Duende-ExtraLarge

Same as 2.5 HK-Blazor-ExtraLarge but with a Duende BFF.

### 2.10 HK-Blazor-Duende-Large

Same as 2.6 HK-Blazor-Large but with a Duende BFF.

### 2.11 HK-Blazor-Duende-Medium

Same as 2.7 HK-Blazor-Medium but with a Duende BFF.

### 2.12 HK-Blazor-Duende-Small

Same as 2.8 HK-Blazor-Small but with a Duende BFF.

### 2.13 HK-NuGet-Package-ExtraLarge

- Source
	- Project
		- Project.csproj
		- ReadMe.md
- Tests
	- Integration-tests
		- Integration-tests.csproj
	- Unit-tests
		- Unit-tests.csproj
	- .editorconfig
	- Directory.Build.props
	- Directory.Build.targets
- .editorconfig
- .gitignore
- Build.yml
- Deploy.yml
- Directory.Build.props
- Directory.Build.targets
- Name.sln (the --name parameter when you create it)
- NuGet.config
- Pipeline.yml
- ReadMe.md
- Variables.yml

### 2.14 HK-NuGet-Package-Large

- Source
	- Project
		- Project.csproj
		- ReadMe.md
- Tests
	- Integration-tests
		- Integration-tests.csproj
	- Unit-tests
		- Unit-tests.csproj
	- .editorconfig
	- Directory.Build.props
	- Directory.Build.targets
- .editorconfig
- .gitignore
- Directory.Build.props
- Directory.Build.targets
- Name.sln (the --name parameter when you create it)
- NuGet.config
- ReadMe.md

### 2.15 HK-NuGet-Package-Medium

- Source
	- Project
		- Project.csproj
		- ReadMe.md
- Tests
	- Integration-tests
		- Integration-tests.csproj
	- Unit-tests
		- Unit-tests.csproj
	- .editorconfig
- .editorconfig
- .gitignore
- Name.sln (the --name parameter when you create it)
- NuGet.config
- ReadMe.md

### 2.16 HK-NuGet-Package-Small

- Source
	- Project
		- Project.csproj
		- ReadMe.md
- .editorconfig
- .gitignore
- Name.sln (the --name parameter when you create it)
- NuGet.config
- ReadMe.md

### 2.17 HK-React-ExtraLarge

- .kubernetes
	- EgressFirewall.development-cluster.yml
	- EgressFirewall.production-cluster.yml
	- ReadMe.md
	- Template.yml
- Source
	- Bff
		- ...
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Bff.csproj
		- Dockerfile
		- ...
	- Spa
		- .vscode
			- launch.json
		- public
			- favicon.ico
		- src
			- style
				- parts
					- ...
				- site.scss
			- App.tsx
			- Index.tsx
			- vite-env.d.ts
		- ...
		- Directory.Build.props
		- Directory.Build.targets
		- index.html
		- package.json
		- ...
		- Spa.esproj
		- tsconfig.json
		- tsconfig.node.json
		- vite.config.ts
- Tests
	- Integration-tests
		- Integration-tests.csproj
	- Unit-tests
		- Unit-tests.csproj
	- .editorconfig
	- Directory.Build.props
	- Directory.Build.targets
- .dockerignore
- .editorconfig
- .gitignore
- Build.yml
- Deploy.yml
- Directory.Build.props
- Directory.Build.targets
- Name.sln (the --name parameter when you create it)
- NuGet.config
- Pipeline.yml
- ReadMe.md
- Variables.yml

### 2.18 HK-React-Large

- Source
	- Bff
		- ...
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Bff.csproj
		- Dockerfile
		- ...
	- Spa
		- .vscode
			- launch.json
		- public
			- favicon.ico
		- src
			- style
				- parts
					- ...
				- site.scss
			- App.tsx
			- Index.tsx
			- vite-env.d.ts
		- ...
		- Directory.Build.props
		- Directory.Build.targets
		- index.html
		- package.json
		- ...
		- Spa.esproj
		- tsconfig.json
		- tsconfig.node.json
		- vite.config.ts
- Tests
	- Integration-tests
		- Integration-tests.csproj
	- Unit-tests
		- Unit-tests.csproj
	- .editorconfig
	- Directory.Build.props
	- Directory.Build.targets
- .dockerignore
- .editorconfig
- .gitignore
- Directory.Build.props
- Directory.Build.targets
- Name.sln (the --name parameter when you create it)
- NuGet.config
- ReadMe.md

### 2.19 HK-React-Medium

- Source
	- Bff
		- ...
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Bff.csproj
		- Dockerfile
		- ...
	- Spa
		- .vscode
			- launch.json
		- public
			- favicon.ico
		- src
			- style
				- parts
					- ...
				- site.scss
			- App.tsx
			- Index.tsx
			- vite-env.d.ts
		- ...
		- Directory.Build.props
		- Directory.Build.targets
		- index.html
		- package.json
		- ...
		- Spa.esproj
		- tsconfig.json
		- tsconfig.node.json
		- vite.config.ts
- Tests
	- Integration-tests
		- Integration-tests.csproj
	- Unit-tests
		- Unit-tests.csproj
	- .editorconfig
- .dockerignore
- .editorconfig
- .gitignore
- Name.sln (the --name parameter when you create it)
- NuGet.config
- ReadMe.md

### 2.20 HK-React-Small

- Source
	- Bff
		- ...
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Bff.csproj
		- Dockerfile
		- ...
	- Spa
		- .vscode
			- launch.json
		- public
			- favicon.ico
		- src
			- style
				- parts
					- ...
				- site.scss
			- App.tsx
			- Index.tsx
			- vite-env.d.ts
		- ...
		- Directory.Build.props
		- Directory.Build.targets
		- index.html
		- package.json
		- ...
		- Spa.esproj
		- tsconfig.json
		- tsconfig.node.json
		- vite.config.ts
- .dockerignore
- .editorconfig
- .gitignore
- Name.sln (the --name parameter when you create it)
- NuGet.config
- ReadMe.md

### 2.21 HK-React-Duende-ExtraLarge

Same as 2.17 HK-React-ExtraLarge but with a Duende BFF.

### 2.22 HK-React-Duende-Large

Same as 2.18 HK-React-Large but with a Duende BFF.

### 2.23 HK-React-Duende-Medium

Same as 2.19 HK-React-Medium but with a Duende BFF.

### 2.24 HK-React-Duende-Small

Same as 2.20 HK-React-Small but with a Duende BFF.

### 2.25 HK-Service-ExtraLarge

- .kubernetes
	- EgressFirewall.development-cluster.yml
	- EgressFirewall.production-cluster.yml
	- ReadMe.md
	- Template.yml
- Source
	- Service
		- ...
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Dockerfile
		- Program.cs
		- Service.csproj
		- Service.http
- Tests
	- Integration-tests
		- Integration-tests.csproj
	- Unit-tests
		- Unit-tests.csproj
	- .editorconfig
	- Directory.Build.props
	- Directory.Build.targets
- .dockerignore
- .editorconfig
- .gitignore
- Build.yml
- Deploy.yml
- Directory.Build.props
- Directory.Build.targets
- Name.sln (the --name parameter when you create it)
- NuGet.config
- Pipeline.yml
- ReadMe.md
- Variables.yml

### 2.26 HK-Service-Large

- Source
	- Service
		- ...
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Dockerfile
		- Program.cs
		- Service.csproj
		- Service.http
- Tests
	- Integration-tests
		- Integration-tests.csproj
	- Unit-tests
		- Unit-tests.csproj
	- .editorconfig
	- Directory.Build.props
	- Directory.Build.targets
- .dockerignore
- .editorconfig
- .gitignore
- Directory.Build.props
- Directory.Build.targets
- Name.sln (the --name parameter when you create it)
- NuGet.config
- ReadMe.md

### 2.27 HK-Service-Medium

- Source
	- Service
		- ...
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Dockerfile
		- Program.cs
		- Service.csproj
		- Service.http
- Tests
	- Integration-tests
		- Integration-tests.csproj
	- Unit-tests
		- Unit-tests.csproj
	- .editorconfig
- .dockerignore
- .editorconfig
- .gitignore
- Name.sln (the --name parameter when you create it)
- NuGet.config
- ReadMe.md

### 2.28 HK-Service-Small

- Source
	- Service
		- ...
		- appsettings.json
		- appsettings.Deploy.json
			- appsettings.Deploy.Production.json
			- appsettings.Deploy.Stage.json
			- appsettings.Deploy.Test.json
		- appsettings.Development.json
		- Dockerfile
		- Program.cs
		- Service.csproj
		- Service.http
- .dockerignore
- .editorconfig
- .gitignore
- Name.sln (the --name parameter when you create it)
- NuGet.config
- ReadMe.md