using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bff.Pages
{
	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	[IgnoreAntiforgeryToken]
	public class ErrorModel(ILoggerFactory loggerFactory) : PageModel
	{
		#region Properties

		protected internal virtual ILogger Logger { get; } = (loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory))).CreateLogger(typeof(ErrorModel));
		public string? RequestId { get; set; }
		public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);

		#endregion

		#region Methods

		public virtual void OnGet()
		{
			this.RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier;
		}

		#endregion
	}
}