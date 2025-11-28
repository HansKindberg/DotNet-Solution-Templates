using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class ExampleController(ILoggerFactory loggerFactory) : ControllerBase
	{
		#region Properties

		protected internal virtual ILogger Logger { get; } = (loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory))).CreateLogger<ExampleController>();

		#endregion

		#region Methods

		[HttpGet]
		public virtual async Task<string?> Get()
		{
			await Task.CompletedTask;

			this.Logger.LogDebug("Get");

			return $"Random value: {new Random().Next(1, 1000)}";
		}

		#endregion
	}
}