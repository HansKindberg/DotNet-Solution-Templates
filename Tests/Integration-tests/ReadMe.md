# Integration-tests

## xunit.runner.json

Currently, we run the tests sequentially so that they don't fail.

- [Config with xunit.runner.json](https://xunit.net/docs/config-xunit-runner-json)
- [Config with xunit.runner.json - parallelizeTestCollections](https://xunit.net/docs/config-xunit-runner-json#parallelizeTestCollections)

The xunit.runner.json can not contain comments. It is ignored when it has comments. Before we had this:

	{
		"$schema": "https://xunit.net/schema/current/xunit.runner.schema.json",
		// https://xunit.net/docs/config-xunit-runner-json
		"parallelizeTestCollections": false // Sequential, https://xunit.net/docs/config-xunit-runner-json#parallelizeTestCollections
	}

We had to change to this:

	{
		"$schema": "https://xunit.net/schema/current/xunit.runner.schema.json",
		"parallelizeTestCollections": false
	}

Issue:

- [Xunit silently ignores xunit.runner.json when the file contains comments #1654](https://github.com/xunit/xunit/issues/1654)