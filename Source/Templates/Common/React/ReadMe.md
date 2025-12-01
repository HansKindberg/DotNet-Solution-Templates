# Name_76ff7a7e_db48_4849_bc2c_2790d679ce88

## 1 Development

Below is just for development. When publishing/deploying the solution, the Bff-application, the Spa-application will end up as two files under the wwwroot/assets folder:

- wwwroot/assets/*.css
- wwwroot/assets/*.js

### 1.1 Multiple startup projects

The solution has two projects:

- Bff, https://localhost:5001
- Spa, https://localhost:5000

For development there is a launch profile named "Bff-Spa" that starts both the projects. The "Bff-Spa" launch profile is saved in a file named "Launch-profiles.slnLaunch".

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