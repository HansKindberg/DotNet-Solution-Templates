using Bff.Models.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Bff.Models.Web
{
	public class BffMiddleware
	{
		#region Constructors

		public BffMiddleware(ILoggerFactory loggerFactory, RequestDelegate next, IOptionsMonitor<BffOptions> optionsMonitor)
		{
			this.Logger = (loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory))).CreateLogger(this.GetType());
			this.Next = next ?? throw new ArgumentNullException(nameof(next));
			this.OptionsMonitor = optionsMonitor ?? throw new ArgumentNullException(nameof(optionsMonitor));
		}

		#endregion

		#region Properties

		protected internal virtual ILogger Logger { get; }
		protected internal virtual RequestDelegate Next { get; }
		protected internal virtual IOptionsMonitor<BffOptions> OptionsMonitor { get; }

		#endregion

		#region Methods

		public async Task Invoke(HttpContext context)
		{
			var endpoint = context.GetEndpoint();

			if(endpoint != null)
			{
				var controllerAttribute = endpoint.Metadata.GetMetadata<ControllerAttribute>();

				if(controllerAttribute != null)
				{
					var options = this.OptionsMonitor.CurrentValue;

					if(options.AntiForgeryEnabled)
					{
						var antiForgeryHeader = context.Request.Headers[options.AntiForgeryHeaderName].FirstOrDefault();

						if(antiForgeryHeader == null || antiForgeryHeader != options.AntiForgeryHeaderValue)
						{
							this.Logger.LogError("Anti-forgery validation failed. Local path: \"{0}\"", context.Request.Path);

							context.Response.StatusCode = 401;
							return;
						}
					}
				}
			}

			await this.Next(context);
		}

		#endregion
	}
}