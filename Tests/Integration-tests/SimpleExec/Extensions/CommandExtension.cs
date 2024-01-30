using System.Runtime.InteropServices;
using System.Text;

namespace IntegrationTests.SimpleExec.Extensions
{
	public static class CommandExtension
	{
		#region Methods

		public static async Task<(string StandardOutput, string StandardError)> ReadAsync(string name, string args = "", string workingDirectory = "", Action<IDictionary<string, string?>>? configureEnvironment = null, Encoding? encoding = null, Func<int, bool>? handleExitCode = null, string? standardInput = null, bool cancellationIgnoresProcessTree = false, CancellationToken cancellationToken = default)
		{
			ResolveRunArguments(args, name, out var resolvedArguments, out var resolvedName);

			return await global::SimpleExec.Command.ReadAsync(resolvedName, resolvedArguments, workingDirectory, configureEnvironment, encoding, handleExitCode, standardInput, cancellationIgnoresProcessTree, cancellationToken);
		}

		public static async Task<(string StandardOutput, string StandardError)> ReadAsync(string name, IEnumerable<string> args, string workingDirectory = "", Action<IDictionary<string, string?>>? configureEnvironment = null, Encoding? encoding = null, Func<int, bool>? handleExitCode = null, string? standardInput = null, bool cancellationIgnoresProcessTree = false, CancellationToken cancellationToken = default)
		{
			ResolveRunArguments(args, name, out var resolvedArguments, out var resolvedName);

			return await global::SimpleExec.Command.ReadAsync(resolvedName, resolvedArguments, workingDirectory, configureEnvironment, encoding, handleExitCode, standardInput, cancellationIgnoresProcessTree, cancellationToken);
		}

		private static void ResolveRunArguments(string arguments, string name, out string resolvedArguments, out string resolvedName)
		{
			resolvedArguments = arguments;
			resolvedName = name;

			if(!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				return;

			resolvedArguments = $"/C {name}";

			if(!string.IsNullOrEmpty(arguments))
				resolvedArguments += " " + arguments;

			resolvedName = "cmd";
		}

		private static void ResolveRunArguments(IEnumerable<string> arguments, string name, out IEnumerable<string> resolvedArguments, out string resolvedName)
		{
			var argumentList = new List<string>(arguments);

			var argumentsString = argumentList.Count == 0 ? string.Empty : string.Join(" ", argumentList);

			ResolveRunArguments(argumentsString, name, out var resolvedArgumentsString, out resolvedName);

			resolvedArguments = string.IsNullOrEmpty(resolvedArgumentsString) ? Enumerable.Empty<string>() : resolvedArgumentsString.Split(" ");
		}

		public static void Run(string name, string args = "", string workingDirectory = "", bool noEcho = false, string? echoPrefix = null, Action<IDictionary<string, string?>>? configureEnvironment = null, bool createNoWindow = false, Func<int, bool>? handleExitCode = null, bool cancellationIgnoresProcessTree = false, CancellationToken cancellationToken = default)
		{
			ResolveRunArguments(args, name, out var resolvedArguments, out var resolvedName);

			global::SimpleExec.Command.Run(resolvedName, resolvedArguments, workingDirectory, noEcho, echoPrefix, configureEnvironment, createNoWindow, handleExitCode, cancellationIgnoresProcessTree, cancellationToken);
		}

		public static void Run(string name, IEnumerable<string> args, string workingDirectory = "", bool noEcho = false, string? echoPrefix = null, Action<IDictionary<string, string?>>? configureEnvironment = null, bool createNoWindow = false, Func<int, bool>? handleExitCode = null, bool cancellationIgnoresProcessTree = false, CancellationToken cancellationToken = default)
		{
			ResolveRunArguments(args, name, out var resolvedArguments, out var resolvedName);

			global::SimpleExec.Command.Run(resolvedName, resolvedArguments, workingDirectory, noEcho, echoPrefix, configureEnvironment, createNoWindow, handleExitCode, cancellationIgnoresProcessTree, cancellationToken);
		}

		public static async Task RunAsync(string name, string args = "", string workingDirectory = "", bool noEcho = false, string? echoPrefix = null, Action<IDictionary<string, string?>>? configureEnvironment = null, bool createNoWindow = false, Func<int, bool>? handleExitCode = null, bool cancellationIgnoresProcessTree = false, CancellationToken cancellationToken = default)
		{
			ResolveRunArguments(args, name, out var resolvedArguments, out var resolvedName);

			await global::SimpleExec.Command.RunAsync(resolvedName, resolvedArguments, workingDirectory, noEcho, echoPrefix, configureEnvironment, createNoWindow, handleExitCode, cancellationIgnoresProcessTree, cancellationToken);
		}

		public static async Task RunAsync(string name, IEnumerable<string> args, string workingDirectory = "", bool noEcho = false, string? echoPrefix = null, Action<IDictionary<string, string?>>? configureEnvironment = null, bool createNoWindow = false, Func<int, bool>? handleExitCode = null, bool cancellationIgnoresProcessTree = false, CancellationToken cancellationToken = default)
		{
			ResolveRunArguments(args, name, out var resolvedArguments, out var resolvedName);

			await global::SimpleExec.Command.RunAsync(resolvedName, resolvedArguments, workingDirectory, noEcho, echoPrefix, configureEnvironment, createNoWindow, handleExitCode, cancellationIgnoresProcessTree, cancellationToken);
		}

		#endregion
	}
}