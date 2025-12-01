# Name-._76ff7a7e-._db48-._4849-._bc2c-._2790d679ce88

## 1 Development

Below is just for development. When publishing/deploying the solution, the Bff-application, the Spa-application will end up as two files under the wwwroot/assets folder:

- wwwroot/assets/*.css
- wwwroot/assets/*.js

### 1.1 Multiple startup projects

The solution has two projects:

- Bff, https://localhost:5001
- Spa, https://localhost:5000

For development there is a launch profile named "Bff-Spa" that starts both the projects. The "Bff-Spa" launch profile is saved in the Name-._76ff7a7e-._db48-._4849-._bc2c-._2790d679ce88.slnLaunch file.

### 1.2 Bff

The Duende Bff is configured to use a "/bff" prefix for certain routes by default:

[BFF Session Management Endpoints](https://docs.duendesoftware.com/identityserver/v7/bff/session/management/)

Endpoints:

- BFF Login Endpoint
- BFF User Endpoint
- BFF Logout Endpoint
- BFF Silent Login Endpoint
- BFF Diagnostics Endpoint
- BFF Back-Channel Logout Endpoint

There is also an example-controller in the Bff:

- Bff.Controllers.ExampleController

### 1.3 vite.config.ts

When we start (run) the solution the browser will launch and arrive at https://localhost:5000.

The paths to the Bff endpoints must be proxied so we can use relative paths from the Spa application. eg. "/bff/login", "/example/get" etc.:

- [Proxy](/Source/Spa/vite.config.ts#39)
- [Mappings](/Source/Spa/vite.config.ts#58)

If we change the "/bff"-prefix:

	builder.Services.AddBff(options =>
	{
		options.ManagementBasePath = "/my-bff-base-path";
	});

we have to change the mappings from:

	proxy: {
		'^/bff': proxy,
		'^/example': proxy
	}

to:

	proxy: {
		'^/example': proxy,
		'^/my-bff-base-path': proxy
	}

Depending on the controllers (routes) we add they have to be mapped:

	proxy: {
		'^/bff': proxy,
		'^/first': proxy,
		'^/second': proxy,
		'^/third': proxy
	}

in case the controllers we add are:

- Bff.Controllers.FirstController
- Bff.Controllers.SecondController
- Bff.Controllers.ThirdController

## 2 Environment

## 3 Deploy