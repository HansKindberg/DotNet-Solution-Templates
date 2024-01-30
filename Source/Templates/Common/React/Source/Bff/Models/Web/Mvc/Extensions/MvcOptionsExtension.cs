using Bff.Models.Web.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc;

namespace Bff.Models.Web.Mvc.Extensions
{
	public static class MvcOptionsExtension
	{
		#region Methods

		public static MvcOptions AddRoutePrefix(this MvcOptions options, string prefix)
		{
			options.Conventions.Add(new RoutePrefixConvention(prefix));

			return options;
		}

		#endregion
	}
}