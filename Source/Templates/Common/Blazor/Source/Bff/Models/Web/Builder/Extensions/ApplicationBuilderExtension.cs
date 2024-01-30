namespace Bff.Models.Web.Builder.Extensions
{
	public static class ApplicationBuilderExtension
	{
		#region Methods

		public static IApplicationBuilder UseBff(this IApplicationBuilder applicationBuilder)
		{
			return applicationBuilder.UseMiddleware<BffMiddleware>();
		}

		#endregion
	}
}