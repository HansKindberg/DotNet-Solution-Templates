namespace Bff.Models.Configuration
{
	public class BffOptions
	{
		#region Properties

		public virtual bool AntiForgeryEnabled { get; set; } = true;
		public virtual string AntiForgeryHeaderName { get; set; } = "X-CSRF";
		public virtual string AntiForgeryHeaderValue { get; set; } = "1";
		public virtual string RoutePrefix { get; set; } = ConfigurationKeys.BffPath.ToLowerInvariant();
		public virtual bool RoutePrefixEnabled { get; set; } = true;

		#endregion
	}
}