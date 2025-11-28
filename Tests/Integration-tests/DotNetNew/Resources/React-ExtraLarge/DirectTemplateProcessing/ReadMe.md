# Name_76ff7a7e_db48_4849_bc2c_2790d679ce88

## 1 Development

Below is just for development. When publishing/deploying the solution, the Bff-application, the Spa-application will end up as two files under the wwwroot/assets folder:

- wwwroot/assets/*.css
- wwwroot/assets/*.js

### 1.1 Multiple startup projects

The solution has two projects:

- Bff, https://localhost:5001
- Spa, https://localhost:5000

During development we need to setup multiple startup projects.

1. Right click the solution in **Solution Explorer**

2. Click **Configure Startup Projects...**

3. Check **Multiple startup projects:**

4. Set action to **Start** on both the **Bff** and **Spa** project

Hopefully there will come a solution for saving multiple startup projects to source control.

- [Master .slnLaunch for Visual Studio 2022: Source-Controlled Multi-Project Startup Configurations!](https://www.youtube.com/watch?v=XJvIX4rCWCk)

### 1.2 Bff

The Bff is configured to add a "/bff" prefix on all routes by default. This can be disabled in appsettings:

	{
		...,
		"Bff": {
			"RoutePrefixEnabled": false
		},
		...
	}

or, the prefix can be changed:


	{
		...,
		"Bff": {
			"RoutePrefix": "my-route-prefix"
		},
		...
	}

There is also an example-controller:

- Bff.Controllers.ExampleController

### 1.3 vite.config.ts

When we start (run) the solution the browser will launch and arrive at https://localhost:5000.

The paths to the Bff endpoints must be proxied so we can use relative paths from the Spa application. eg. "/bff/example/get":

- [Proxy](/Source/Spa/vite.config.ts#39)
- [Mappings](/Source/Spa/vite.config.ts#58)

So if we disable the route-prefix in the Bff we have to change the mappings from:

	proxy: {
		'^/bff': proxy
	}

to:

	proxy: {
		'^/example': proxy
	}

Depending on the controllers (routes) we add they have to be mapped:

	proxy: {
		'^/first': proxy,
		'^/second': proxy,
		'^/third': proxy
	}

in case the controllers we add are:

- Bff.Controllers.FirstController
- Bff.Controllers.SecondController
- Bff.Controllers.ThirdController

If we change the route-prefix to eg. "my-route-prefix" in the Bff we have to change the mappings from:

	proxy: {
		'^/bff': proxy
	}

to:

	proxy: {
		'^/my-route-prefix': proxy
	}

## 2 Environment

## 3 Deploy

### 3.1 One-time setup

#### 3.1.1 Create a new pipeline in Azure DevOps

Create a new pipeline and point it to Pipeline.yml in the repository-root. Rename it to "Build & deploy".

1. Select "Pipelines" in your Azure DevOps project
2. New pipeline
3. Azure Repos Git (YAML)
4. Select a repository -> select your repository
5. Configure your pipeline -> Existing Azure Pipelines YAML file
6. Select an existing YAML file -> select "/Pipeline.yml" under "Path" -> Continue
7. Select "Save" in the "Run"-dropdown
8. Select "Rename/move" in the "3-dot"-dropdown
9. Rename/move pipeline -> Enter "Build & deploy" for "Name" -> Save

#### 3.1.2 Kubernetes

The steps below are written with the assumption that you use OpenShift. But the idea is that other Kubernetes software should work in a similar way.

We have to set up a namespace (project) in OpenShift for each environment. By having a namespace for each environment we don't have to care about naming conflicts. Each namespace/environment gets it's own resources. The resources can be named the same in each namespace and gets isolated from the other namespaces.

Environments:

- Development-cluster
	- **Stage**
	- **Test**

- Production-cluster
	- **Production**

The following steps are for each environment:

1. Get a login-token

	Go to the following url to get a login token. Note/copy it.

	https://oauth-openshift.apps.dev.example.org/oauth/token/request

	or

	https://oauth-openshift.apps.prod.example.org/oauth/token/request

2. Login with your token

		oc login https://api.dev.example.org:1234 --token={token}

	or

		oc login https://api.prod.example.org:1234 --token={token}

3. Create a project (namespace)

		oc new-project example-application-production

	or

		oc new-project example-application-stage

	or

		oc new-project example-application-test

4. Verify that you are using the correct project (namespace)

		oc project

	it should give the follwing result:

		Using project "example-application-production" on server "https://api.prod.example.org:1234".

	or

		Using project "example-application-stage" on server "https://api.dev.example.org:1234".

	or

		Using project "example-application-test" on server "https://api.dev.example.org:1234".

5. Create a service-account

		oc create sa azure-devops

    - https://docs.openshift.com/container-platform/4.14/authentication/understanding-and-creating-service-accounts.html

6. Give the service-account the correct rights

		oc policy add-role-to-user edit system:serviceaccount:example-application-production:azure-devops

	or

		oc policy add-role-to-user edit system:serviceaccount:example-application-stage:azure-devops

	or

		oc policy add-role-to-user edit system:serviceaccount:example-application-test:azure-devops

7. Create a token for the service-account
											
		oc create token azure-devops --duration=315576000s

	315576000 seconds = 10 years. Time-converter: https://www.unitconverters.net/time-converter.html

	**Note/copy the token-value.** It should be added as value for the secret variables later.

8. EgressFirewall

	Replace the EgressFirewall if your application "communicates" with external resources, like a database or logging-endpoint for example.

	**You will probably not have permissions for this so you need to ask an admin! Or ask to be joined to the system:muchos-derechos group/role.**

	To be able to connect to external resources, like a database or logging-endpoint, we need to replace the EgressFirewall.

		oc replace -f {PATH-TO-THIS-SOLUTION}\.kubernetes\EgressFirewall.production-cluster.yml -n example-application-production

	or

		oc replace -f {PATH-TO-THIS-SOLUTION}\.kubernetes\EgressFirewall.development-cluster.yml -n example-application-stage

	or

		oc replace -f {PATH-TO-THIS-SOLUTION}\.kubernetes\EgressFirewall.development-cluster.yml -n example-application-test

#### 3.1.3 Secret variables

Create secret variables for the pipeline. To add a secret variable:

1. Select "Pipelines" in your Azure DevOps project
2. Select "Build & deploy"
3. Edit
4. Variables
5. \+
6. Enter name and value -> Check "Keep this value secret" -> OK
7. Save

Add the following secret variables:

- **IMAGE_REGISTRY_TOKEN**

	The token needed to connect to the external image-registry.

- Kubernetes tokens:

	The following secret varibles should get their value from 3.1.2 Kubernetes - step 7

	- **KUBERNETES_API_TOKEN_PRODUCTION**
	- **KUBERNETES_API_TOKEN_STAGE**
	- **KUBERNETES_API_TOKEN_TEST**

#### 3.1.4 Tip

Set approval on the production-environment in Azure DevOps. If you run the pipeline the environment will be created the first time. If you want to set approval before you run the pipeline, a first time, you have to create the "Production" environment manually:

1. Select "Pipelines" -> "Environments" - in your Azure DevOps project
2. New environment
3. Enter "Production" for "Name" -> Select "None" for "Resource" -> Create

Set approval:

1. Select the "Production"-environment
2. Select "Approvals and checks" in the "3-dot"-dropdown
3. Select "Approvals"
4. Add the approvers you want -> Create