using Bff.Models.Web.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Bff.Models.Configuration
{
	public class ConfigureMvcOptions(IOptions<BffOptions> bffOptions) : IConfigureOptions<MvcOptions>
	{
		#region Properties

		protected internal virtual IOptions<BffOptions> BffOptions { get; } = bffOptions ?? throw new ArgumentNullException(nameof(bffOptions));

		#endregion

		#region Methods

		public virtual void Configure(MvcOptions options)
		{
			ArgumentNullException.ThrowIfNull(options);

			var bffOptions = this.BffOptions.Value;

			if(!bffOptions.RoutePrefixEnabled)
				return;

			options.AddRoutePrefix(bffOptions.RoutePrefix);
		}

		#endregion
	}
}